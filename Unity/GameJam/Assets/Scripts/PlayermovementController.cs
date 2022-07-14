using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayermovementController : MonoBehaviour
{
    //Rigidbody of player
    public Rigidbody rb;
    public int boostpadVelocity = 100;
    public int jumppadVelocity = 500;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(rb.velocity);
        // if the player gets too low or too far away, the scene reloads
        if (rb.position.y < -50 || 
            rb.position.x < -200 || 
            rb.position.x > 200 || 
            rb.position.z < -200 ||
            rb.position.z > 200)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        switch(collider.gameObject.tag) {
            case "boostpad":
                rb.AddForce(rb.velocity * boostpadVelocity);
            break;
            case "jumppad":
                rb.AddForce(new Vector3(0, jumppadVelocity, 0));
            break;
        }
    }
}
