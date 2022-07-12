using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent = transform.parent.gameObject;
        for(int i = 1; i <= parent.gameObject.transform.childCount - 1; i++) 
        {
            parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            rb.gameObject.SetActive(false);
            print(this.gameObject.transform.childCount);
            for(int i = 1; i <= parent.gameObject.transform.childCount - 1; i++)
            {
                parent.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
