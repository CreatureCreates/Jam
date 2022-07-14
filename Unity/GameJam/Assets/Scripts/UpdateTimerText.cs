using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateTimerText : MonoBehaviour
{
    public string counterText;
    private int minutes, seconds, milliseconds;
    public TMP_Text textBox;
    
    // Start is called before the first frame update
    void Start()
    {
        textBox = this.gameObject.GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

        if (minutes < 60)
        {
            counterText = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00").Substring(0, 2);
        }
        else
        {
            counterText = "Over 1 hour";
        }

        textBox.text = counterText;
    }
}
