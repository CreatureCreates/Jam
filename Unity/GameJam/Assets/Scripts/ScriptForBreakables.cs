using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForBreakables : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject parent;
    private AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent = transform.parent.gameObject;
        for(int i = 1; i <= parent.gameObject.transform.childCount - 1; i++) 
        {
            parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        Audio = parent.gameObject.GetComponent<AudioSource>();
        
        
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            rb.gameObject.SetActive(false);
            Audio.Play();
            for(int i = 1; i <= parent.gameObject.transform.childCount - 1; i++)
            {
                parent.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
