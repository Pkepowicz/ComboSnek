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
    public float TimeLeft;

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

        if (TimeLeft > 0)
        {
            TimeLeft -= Time.unscaledDeltaTime;
            UpdateTimer(TimeLeft);
        }
        else
        {
            Debug.Log("Here ending screen UwU");
            TimeLeft = 0;
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

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime);

        TimerText.text = seconds.ToString();
    }
}
