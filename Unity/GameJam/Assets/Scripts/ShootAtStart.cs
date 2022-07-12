using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtStart : MonoBehaviour
{
    private GameObject player;

    private Rigidbody rb;
    private AudioSource shotAudio;
    private SpringJoint joint;
    private float thrust = 10f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        shotAudio = this.gameObject.GetComponent<AudioSource>();

        // joint = player.gameObject.AddComponent<SpringJoint>();
        // joint.autoConfigureConnectedAnchor = false;
        // joint.connectedAnchor = this.gameObject.position;

        rb.AddForce((this.transform.position - player.transform.position) * thrust, ForceMode.Impulse);

        shotAudio.Play();

    }
}
