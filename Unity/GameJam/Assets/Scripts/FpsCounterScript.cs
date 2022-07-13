using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FpsCounterScript : MonoBehaviour
{
    //zet dit op 0 om de fps counter uit te zetten
    public int TurnFpsCounterOn = 0;
    //dit displayt het gemiddelde fps over de laatste 30 instances
    public string AvgFrameRate;
    //Een queue om de laatst berekende fps op te slaan
    private Queue<int> lastFewAverages = new Queue<int>();
 
    public void Update ()
    {
        if(TurnFpsCounterOn == 0)
            return;

        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        lastFewAverages.Enqueue((int)current);

        if(lastFewAverages.Count >= 30) {
            AvgFrameRate = (int)lastFewAverages.Average() + " FPS";
            lastFewAverages.Dequeue();
        }
    }
}
