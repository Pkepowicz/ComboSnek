using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
    public TMP_Text gameOverScore;
    //public TMP_Text timeRemaining;
    public GameObject newHighScore;

    private float currentTimeScale;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = currentTimeScale;
        GameIsPaused = false;
        GameManager.Instance.timeFlows = true;
    }

    public void Pause()
    {
        GameManager.Instance.timeFlows = false;
        currentTimeScale = Time.timeScale;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver()
    {
        GameManager.Instance.timeFlows = false;
        gameOverScreen.SetActive(true);
        gameOverScore.text = GameManager.Instance.score.ToString();
        if (GameManager.Instance.score > LevelManager.Instance.highscore)
        {
            Debug.Log(GameManager.Instance.score + " highscore: " + LevelManager.Instance.highscore);
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
        //timeRemaining.text = time.ToString();
    }

    public void QuitToMenu()
    {
        newHighScore.SetActive(false);
        LevelManager.Instance.LoadMenu();
    }
}
