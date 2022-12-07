using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public LevelManager lvlman;

    private void Start()
    {
        lvlman = LevelManager.Instance;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetSliderValue(float value)
    {
        volumeSlider.value = value;
    }
}
