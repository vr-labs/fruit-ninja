using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyingObjectSpawner : MonoBehaviour
{
    public IFlyingObject[] flyingObjectPrefabs;
    public FlyingObjectPrefabsStorage prefabsStorage;
    public FlyingObjectFactory factory;
    
    [SerializeField]
    public Collider spawnArea;

    public float minForce = 4f;
    public float maxForce = 5f;

    public float maxLifetime = 1f;

    private bool spawnFruitsGoing = false;
    
    private void OnEnable()
    {
        spawnFruitsGoing = true;
        StartCoroutine(SpawnFlyingObject());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    void Start()
    {
        flyingObjectPrefabs = Enum.GetValues(typeof(FlyingObjectType))
            .Cast<FlyingObjectType>()
            .Select((type =>
            {
                var objectPrefab = Instantiate(prefabsStorage.GetPrefabByType(type));
                IFlyingObject flyingObject = factory.GetFlyingObject(objectPrefab, type);
                flyingObject.ObjectPrefab = objectPrefab;
                
                return flyingObject;
            }))
            .ToArray();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Running && spawnFruitsGoing == false)
        {
            spawnFruitsGoing = true;
            StartCoroutine(SpawnFlyingObject());
        }
    }

    IEnumerator SpawnFlyingObject()
    {
        yield return new WaitForSeconds(
            2f
        );
        
        while (GameManager.Instance.GameState == GameState.Running)
        {
            IFlyingObject randomObject = flyingObjectPrefabs[Random.Range(0, flyingObjectPrefabs.Length - 1)];

            Vector3 spawnPosition = GetRandomSpawnPosition();
            float angleZ;
            if (spawnPosition.x < 0.16f)
            {
                angleZ = -4f;
            }
            else if (spawnPosition.x < 0.32f)
            {
                angleZ = -3f;
            }
            else if (spawnPosition.x < 0.48f)
            {
                angleZ = -2f;
            }
            else if (spawnPosition.x < 0.64f)
            {
                angleZ = -1f;
            }
            else if (spawnPosition.x < 0.8f)
            {
                angleZ = 0f;
            }
            else if (spawnPosition.x < 0.96f)
            {
                angleZ = 1f;
            }
            else if (spawnPosition.x < 1.12f)
            {
                angleZ = 2f;
            }
            else if (spawnPosition.x < 1.28f)
            {
                angleZ = 3f;
            }
            else
            {
                angleZ = 4f;
            }

            Quaternion rotation = Quaternion.Euler(-10f, 0f, angleZ);
            GameObject fruit = Instantiate(randomObject.ObjectPrefab, spawnPosition, rotation);
            
            MeshCollider meshCollider = fruit.AddComponent<MeshCollider>();
            meshCollider.convex = true;
                    
            fruit.layer = LayerMask.NameToLayer("Sliceable");
            fruit.transform.localScale = randomObject.GetSize();
            
            Destroy(fruit, maxLifetime);
            
            fruit.AddComponent<Rigidbody>().AddForce(fruit.transform.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
            
            randomObject.Launch();
            
            yield return new WaitForSeconds(Random.Range(GameManager.Instance.MinSpawnInterval, GameManager.Instance.MaxSpawnInterval));
        }

        spawnFruitsGoing = false;
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = spawnArea.bounds.max.y,
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
    }
}
