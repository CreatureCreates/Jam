using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayermovementController : MonoBehaviour
{
    //Rigidbody of player
    public Rigidbody rb;
    public int boostpadVelocity = 250;
    public int jumppadVelocity = 500;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(rb.velocity);
        // if the player gets too low, reload the scene
        if (rb.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        switch(collision.gameObject.tag) {
            case "boostpad":
                rb.AddForce(rb.velocity * boostpadVelocity);
            break;
            case "jumppad":
                rb.AddForce(new Vector3(0, jumppadVelocity, 0));
            break;
        }
        //print($"is colliding with {collision.gameObject.tag}");
        /*
        if(collision.gameObject.CompareTag("boostpad")) {
            rb.AddForce(rb.velocity * 500);
            print("is colliding with");
        }
        */
    }
}
