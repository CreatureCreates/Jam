using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFinishPointer : MonoBehaviour
{
    public Transform finish;
    public Transform pointer;
    // Start is called before the first frame update
    void Start()
    {
        pointer = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = pointer.position - finish.position;
        pointer.rotation = Quaternion.Euler(difference);
        


    }
}
