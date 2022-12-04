using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxSpeedLevel = 10;
    private int currentSpeedLevel = 1;
    
    private void Awake()
    {
        Instance = this;
    }

    public void SpeedUp()
    {
        if(currentSpeedLevel < maxSpeedLevel)
        {
            Time.timeScale += 0.4f;
            currentSpeedLevel += 1;
        }
    }

    public void SpeedDown()
    {
        if (currentSpeedLevel > 0)
        {
            Time.timeScale -= 0.4f;
            currentSpeedLevel -= 1;
        }
    }

}
