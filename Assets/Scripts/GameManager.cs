using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject startText;

    public GameObject completeText;
    public GameObject gameOverText;
    public GameObject nextButton;
    public GameObject restartButton;

    private void Awake()
    {
        Instance = this;
    }
    public enum GameStates
    {
        Start,
        InGame,
        GameOver,
        NextLevel
    }

    public GameStates currentState;
    void Start()
    {
        currentState = GameStates.Start;   
    }
    void Update()
    {
        switch(currentState)
        {
            case GameStates.Start: GameStart();
                break;
            case GameStates.InGame: GameInGame();
                break;
            case GameStates.GameOver: GameOver();
                break;
            case GameStates.NextLevel: GameNextLevel();
                break;
        }
    }

    public void GameStart()
    {
        startText.SetActive(true);

        if (Input.GetKey(KeyCode.Space))
        {
            currentState = GameStates.InGame;
        }
    }

    public void GameInGame()
    {
        startText.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void GameNextLevel()
    {
        nextButton.SetActive(true);
        completeText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
