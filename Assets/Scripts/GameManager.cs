using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TMP_Text TimerText;
    public PanelManager panelManager;
    private AudioSource sound;

    [SerializeField] private int maxSpeedLevel = 10;
    [SerializeField] private float speedStep = 0.6f;
    private int currentSpeedLevel = 1;
    public float timeLeft = 60f;
    public bool timeFlows = true;

    public int score = 0;
    
    private void Awake()
    {
        Instance = this;
        sound = this.transform.GetComponent<AudioSource>();
    }
    public void AddPoints(int points)
    {
        score += points;
        panelManager.UpdateScore(score);
    }
    private void Update()
{
        if (timeFlows)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.unscaledDeltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                GameOver();
                timeLeft = 0;
            }
        }
}

    public float TimeModification()
    {
        return 1 + currentSpeedLevel * speedStep;
    }


    public void SpeedUp()
    {
        if(currentSpeedLevel < maxSpeedLevel)
        {
            Time.timeScale += speedStep;
            currentSpeedLevel += 1;
        }
    }

    public void SpeedDown()
    {
        if (currentSpeedLevel > 0)
        {
            Time.timeScale -= speedStep;
            currentSpeedLevel -= 1;
        }
    }

    public void GameOver()
    {
        Handheld.Vibrate();
        sound.Play();
        Time.timeScale = 0;
        panelManager.GameOver();
    }
    
    public void AddTime()
    {
        this.timeLeft += 0.7f * this.currentSpeedLevel;
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime);

        TimerText.text = seconds.ToString();
    }
}
