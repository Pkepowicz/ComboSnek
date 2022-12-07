using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int highscore = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.transform.GetComponent<AudioSource>().Play();
            highscore = PlayerPrefs.GetInt("highscore");
        }
    }

    public void UpdateHighscore(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "MainMenu")
            {
                Application.Quit();
            }
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
