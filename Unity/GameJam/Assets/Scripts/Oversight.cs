using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oversight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        }
        if (Input.GetKeyDown("2"))
        {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        }
    }
}
