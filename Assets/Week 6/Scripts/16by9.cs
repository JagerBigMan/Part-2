using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioSetter : MonoBehaviour
{
    public void SetAspectRatio169()
    {
        // Calculate width based on the height and aspect ratio (16:9)
        int width = Mathf.RoundToInt(Screen.height * (16f / 9f));

        // Set the resolution with the calculated width, keeping the height and making it fullscreen
        Screen.SetResolution(width, Screen.height, true);
    }
}
