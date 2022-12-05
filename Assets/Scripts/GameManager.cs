using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private int maxSpeedLevel = 10;
    [SerializeField] private float speedStep = 0.6f;
    private int currentSpeedLevel = 1;
    public float timeLeft;
    private bool timeFlows = true;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }

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
