using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScene : MonoBehaviour
{

    private AudioSource Audio;
    private AudioSource[] allAudioSources;


    void Awake()
    {
        Audio = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            StopAllAudio();
            Audio.Play();
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
