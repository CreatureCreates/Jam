using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayermovementController : MonoBehaviour
{
    //Rigidbody of player
    public Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
                rb.AddForce(rb.velocity * 500);
            break;
            case "jumppad":
                rb.AddForce(new Vector3(0, 500, 0));
            break;
        }
        print($"is colliding with {collision.gameObject.tag}");
        /*
        if(collision.gameObject.CompareTag("boostpad")) {
            rb.AddForce(rb.velocity * 500);
            print("is colliding with");
        }
        */
    }
}
