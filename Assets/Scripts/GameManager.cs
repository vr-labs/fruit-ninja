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

    public void Start()
    {
        Score = 0;
    }
    
    public void PauseGame()
    {
        GameState = GameState.Pause;
    }

    public void StartGame()
    {
        GameState = GameState.Running;
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