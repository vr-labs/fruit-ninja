using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState GameState { get; private set; } = GameState.Running;

    public TextMeshProUGUI ScoreText;
    public int Score { get; private set; }
    public float MinSpawnInterval = 0.25f;
    public float MaxSpawnInterval = 1.25f;

    public readonly Vector3 startStopButtonSpawn = new()
    {
        x = 0f,
        y = 0f,
        z = 0f
    };

    public GameObject start;
    public GameObject stop;

    public void Start()
    {
        Score = 0;

        Instantiate(start, startStopButtonSpawn, Quaternion.identity);
        MeshCollider meshCollider = start.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        start.layer = LayerMask.NameToLayer("Sliceable");
    }
    
    public void PauseGame()
    {
        Destroy(stop);
        GameState = GameState.Pause;
        Instantiate(start, startStopButtonSpawn, Quaternion.identity);
        MeshCollider meshCollider = start.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        start.layer = LayerMask.NameToLayer("Sliceable");
    }

    public void StartGame()
    {
        Destroy(start);
        GameState = GameState.Running;
        Instantiate(stop, startStopButtonSpawn, Quaternion.identity);
        MeshCollider meshCollider = stop.AddComponent<MeshCollider>();
        meshCollider.convex = true;

        stop.layer = LayerMask.NameToLayer("Sliceable");
    }

    public void ResetGame()
    {
        MinSpawnInterval = 0.25f;
        MaxSpawnInterval = 1.25f;
        Score = 0;
    }

    public void AddScore(int add)
    {
        Score += add;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score " + Score;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateScore();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

public enum GameState
{
    Pause,
    Running
}