using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    public Transform player;
    public Transform bus;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    { 
        text = this.gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = distance();
    }

    private string distance() 
    {
            float dist = Vector3.Distance(player.position, bus.position);
            return $"{dist.ToString("0")}m";
    }
}
