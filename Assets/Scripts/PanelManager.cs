using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;

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
    }

    public void Pause()
    {
        currentTimeScale = Time.timeScale;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitToMenu()
    {
        LevelManager.Instance.LoadMenu();
    }
}
