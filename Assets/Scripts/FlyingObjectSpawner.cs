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
    
    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 0.01f;
    public float maxForce = 0.02f;

    public float maxLifetime = 1f;
    
    private void OnEnable()
    {
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

    IEnumerator SpawnFlyingObject()
    {
        yield return new WaitForSeconds(2f);
        
        while (enabled)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            IFlyingObject randomObject = null;
            foreach (IFlyingObject prefab in flyingObjectPrefabs)
            {
                if (Random.Range(0f, 1f) <= prefab.AppearingChance)
                {
                    randomObject = prefab;
                    break;
                }
            }

            randomObject ??= flyingObjectPrefabs[0];
            
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            GameObject fruit = Instantiate(randomObject.ObjectPrefab, spawnPosition, rotation);
            
            MeshCollider meshCollider = fruit.AddComponent<MeshCollider>();
            meshCollider.convex = true;
                    
            fruit.layer = LayerMask.NameToLayer("Sliceable");
            fruit.transform.localScale = randomObject.GetSize();
            
            Destroy(fruit, maxLifetime);
            
            float force = Random.Range(minForce, maxForce);
            fruit.AddComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            
            randomObject.Launch();
            
            yield return new WaitForSeconds(Random.Range(GameManager.Instance.MinSpawnInterval, GameManager.Instance.MaxSpawnInterval));
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
    }
}
