using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopSpawner : MonoBehaviour
{
    public static StartStopSpawner Instance { get; private set; }

    [SerializeField]
    public Collider spawnArea;

    [SerializeField]
    public GameObject stopButton;

    [SerializeField]
    public GameObject startButton; 

    private void OnEnable()
    {
        SpawnStop();
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void SpawnStop()
    {
        Vector3 spawnPosition = new(spawnArea.bounds.min.x, spawnArea.bounds.min.y, spawnArea.bounds.min.z);
        GameObject stop = Instantiate(stopButton, spawnPosition, Quaternion.identity);
        ButtonStop buttonStop = stop.AddComponent<ButtonStop>();
        buttonStop.ObjectPrefab = stop;

        MeshCollider meshCollider = stop.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        stop.layer = LayerMask.NameToLayer("Sliceable");
        stop.transform.localScale = buttonStop.GetSize;
    }

    public void SpawnStart()
    {
        Vector3 spawnPosition = new(spawnArea.bounds.max.x, spawnArea.bounds.max.y, spawnArea.bounds.max.z);
        GameObject start = Instantiate(startButton, spawnPosition, Quaternion.identity);
        ButtonStart buttonStart = start.AddComponent<ButtonStart>();
        buttonStart.ObjectPrefab = start;

        MeshCollider meshCollider = start.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        start.layer = LayerMask.NameToLayer("Sliceable");
        start.transform.localScale = buttonStart.GetSize;

    }
}
