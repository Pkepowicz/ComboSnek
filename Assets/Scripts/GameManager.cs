using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TMP_Text TimerText;
    public PanelManager panelManager;

    [SerializeField] private int maxSpeedLevel = 10;
    [SerializeField] private float speedStep = 0.6f;
    private int currentSpeedLevel = 1;
    public float timeLeft = 60f;
    private bool timeFlows = true;

    public int score = 0;
    
    private void Awake()
    {
        Instance = this;
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
                Debug.Log("Here ending screen UwU");
                GameOver();
                timeLeft = 0;
            }
        }
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
        Time.timeScale = 0;
        panelManager.GameOver();
    }
    
    public void AddTime()
    {
        this.timeLeft += 1 * this.currentSpeedLevel;
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime);

        TimerText.text = seconds.ToString();
    }
}
