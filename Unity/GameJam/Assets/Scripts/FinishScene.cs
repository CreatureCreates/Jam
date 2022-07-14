using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScene : MonoBehaviour
{

    private AudioSource Audio;
    private AudioSource[] allAudioSources;
    private Transform truck;
    private bool hasNotPlayedYet = true;

    void Awake()
    {
        Audio = this.gameObject.GetComponent<AudioSource>();
        truck = this.transform.parent.transform;
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player") && hasNotPlayedYet)
        {
            StopAllAudio();
            Audio.Play();

            foreach (Transform child in truck)
            {
                MeshCollider mc = child.gameObject.AddComponent<MeshCollider>();
                Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();
                mc.convex = true;
                mc.isTrigger = true;
                rb.isKinematic = false;
                rb.useGravity = true;


            }
            //truck.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //truck.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // stop all audio
    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }
}
