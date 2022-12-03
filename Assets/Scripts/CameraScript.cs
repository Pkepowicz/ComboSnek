using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public RectTransform bounds;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = (float)bounds.rect.width / (float)bounds.rect.height;
        
        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = bounds.rect.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = bounds.rect.size.y / 2 * differenceInSize;
        }
    }
}
