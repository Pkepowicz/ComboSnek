using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highscore;
    public OptionsMenu optionsMenu;
    private void Start()
    {
        
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        optionsMenu.SetMusic(PlayerPrefs.GetFloat("MusicVolume"));
        optionsMenu.SetSFX(PlayerPrefs.GetFloat("SFXVolume"));
        optionsMenu.SetSliderValue(PlayerPrefs.GetFloat("MusicVolume"), 
        PlayerPrefs.GetFloat("SFXVolume"));
    }

    public void PlayGame()
    {
        LevelManager.Instance.LoadGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
