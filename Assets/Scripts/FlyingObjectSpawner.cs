using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyingObjectSpawner : MonoBehaviour
{
    public List<IFlyingObject> flyingObjectPrefabs;
    public FlyingObjectPrefabsStorage prefabsStorage;
    public FlyingObjectFactory factory;
    
    [SerializeField]
    public GameObject spawnArea;
    
    [SerializeField]
    public float spawnInterval = 10.0f;
    private float nextSpawnTime;

    void Start()
    {
        flyingObjectPrefabs = Enum.GetValues(typeof(FlyingObjectType)).Cast<FlyingObjectType>()
            .Select((type =>
            {
                IFlyingObject flyingObject = factory.GetFlyingObject(gameObject, type);
                flyingObject.ObjectPrefab = prefabsStorage.GetPrefabByType(type);
                
                MeshCollider meshCollider = flyingObject.ObjectPrefab.AddComponent<MeshCollider>();
                meshCollider.convex = true;
                flyingObject.ObjectPrefab.layer = LayerMask.NameToLayer("Sliceable");
                flyingObject.ObjectPrefab.transform.localScale = flyingObject.GetSize();

                return flyingObject;
            }))
            .ToList();
        
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnFlyingObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnFlyingObject()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        IFlyingObject randomObject = flyingObjectPrefabs[Random.Range(0, flyingObjectPrefabs.Count)];
        
        Instantiate(randomObject.ObjectPrefab, spawnPosition, Quaternion.identity);
        randomObject.Launch();
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnAreaPosition = spawnArea.transform.position;
        Vector3 spawnAreaScale = spawnArea.transform.localScale;

        float minX = spawnAreaPosition.x - spawnAreaScale.x * 3;
        float maxX = spawnAreaPosition.x + spawnAreaScale.x * 3;
        float minZ = spawnAreaPosition.z - spawnAreaScale.z * 3;
        float maxZ = spawnAreaPosition.z + spawnAreaScale.z * 3;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        
        // TODO убрать + 1f после полёта
        return new Vector3(randomX, spawnAreaPosition.y + 1f, randomZ);
    }
}
