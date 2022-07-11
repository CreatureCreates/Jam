using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounterScript : MonoBehaviour
{
    public int avgFrameRate;
    public string text;
 
    public void Update ()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        text = avgFrameRate.ToString() + " FPS";

    }
}
