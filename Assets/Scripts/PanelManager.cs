using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
    public TMP_Text gameOverScore;
    public TMP_Text timeRemaining;
    public GameObject newHighScore;

    private float currentTimeScale;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (!GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            // just for testing on computer
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = currentTimeScale;
        GameIsPaused = false;
    }

    public void Pause()
    {
        currentTimeScale = Time.timeScale;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScore.text = GameManager.Instance.score.ToString();
        if (GameManager.Instance.score > LevelManager.Instance.highscore)
        {
            newHighScore.SetActive(true);
            LevelManager.Instance.UpdateHighscore(GameManager.Instance.score);
        }
    }

    public void Restart()
    {
        newHighScore.SetActive(false);
        LevelManager.Instance.LoadGame();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score " + score;
    }

    public void UpdateTime(float time)
    {
        timeRemaining.text = time.ToString();
    }

    public void QuitToMenu()
    {
        newHighScore.SetActive(false);
        LevelManager.Instance.LoadMenu();
    }
}
