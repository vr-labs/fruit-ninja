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

    public void SpawnStop()
    {
        Vector3 spawnPosition = new(spawnArea.bounds.min.x, spawnArea.bounds.min.y, spawnArea.bounds.min.z);
        var objectPrefab = Instantiate(stopButton);
        ButtonStop buttonStop = objectPrefab.AddComponent<ButtonStop>();
        GameObject stop = Instantiate(buttonStop.ObjectPrefab, spawnPosition, Quaternion.identity);

        MeshCollider meshCollider = stop.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        stop.layer = LayerMask.NameToLayer("Sliceable");
        stop.transform.localScale = buttonStop.GetSize;
    }

    public void SpawnStart()
    {
        Vector3 spawnPosition = new(spawnArea.bounds.min.x, spawnArea.bounds.min.y, spawnArea.bounds.min.z);
        var objectPrefab = Instantiate(startButton);
        ButtonStart buttonStart = objectPrefab.AddComponent<ButtonStart>();
        GameObject start = Instantiate(buttonStart.prefab, spawnPosition, Quaternion.identity);

        MeshCollider meshCollider = start.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        start.layer = LayerMask.NameToLayer("Sliceable");
        start.transform.localScale = buttonStart.GetSize;

    }
}
