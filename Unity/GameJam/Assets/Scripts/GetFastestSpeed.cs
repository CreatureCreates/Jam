using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetFastestSpeed : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textBox;
        string stringTime;

        textBox = this.gameObject.GetComponent<TMP_Text>();
        string sceneName = this.gameObject.name.Substring(this.gameObject.name.Length - 6);
        string winTimeSceneName = "winTime" + sceneName;

        stringTime = PlayerPrefs.GetString(winTimeSceneName, "unfinished");

        if (stringTime != "unfinished")
        {
            textBox.text = stringTime;
        }
        else
        {
            textBox.text = "unplayed";
        }
    }
}
