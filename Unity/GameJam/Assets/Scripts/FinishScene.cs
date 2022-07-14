using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{

    public float winTime;
    private AudioSource Audio;
    private AudioSource[] allAudioSources;
    private Transform truck;
    private string previous_time;


    void Awake()
    {
        Audio = this.gameObject.GetComponent<AudioSource>();
        truck = this.transform.parent.transform;
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            // play win audio
            StopAllAudio();
            Audio.Play();

            foreach (Transform child in truck)
            {
                if(child.name == "CargoHolder") 
                {
                    child.GetComponent<MeshCollider>().convex = true;
                }
                MeshCollider mc = child.gameObject.AddComponent<MeshCollider>();
                child.gameObject.AddComponent<Rigidbody>();
                Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();
                mc.convex = true;
                mc.isTrigger = true;
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.mass = -0f;


            }
            //truck.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //truck.gameObject.GetComponent<Rigidbody>().useGravity = true;
            // save win time
            int winTime = (int)(Time.timeSinceLevelLoad * 1000f);
            string stringTime = IntTimeToString(winTime);

            string sceneName = SceneManager.GetActiveScene().name;
            string winTimeSceneName = "winTime" + sceneName;
            string winTimeSceneNameFloat = winTimeSceneName + "Float";


            float defaultFloat = 3600000f;

            string prevTimeString = PlayerPrefs.GetString(winTimeSceneName, "unfinished");
            float prevTimeFloat = PlayerPrefs.GetFloat(winTimeSceneNameFloat, defaultFloat);

            print("defaultFloat");
            print(defaultFloat);
            print("winTime");
            print(winTime);
            print("prevTimeFloat");
            print(prevTimeFloat);

            if (winTime < prevTimeFloat || prevTimeFloat == 0)
            {
                PlayerPrefs.SetString(winTimeSceneName, stringTime);
                PlayerPrefs.SetFloat(winTimeSceneNameFloat, winTime);
            }

            print(winTimeSceneName);
            print(prevTimeString);
            print(PlayerPrefs.GetString(winTimeSceneName, "unfinished"));
        }
    }

    // stop all audio
    void StopAllAudio() 
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }

    public string IntTimeToString(int time)
    {
        string timeText;

        if (time < 3600000)
        {
            time = time / 1000;

            float minutes = (time / 60f) % 60;
            float seconds = (time % 60f);
            float milliseconds = (time * 1000f) % 1000;
            
            timeText = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00").Substring(0, 2);
        }
        else
        {
            timeText = "too slow";
        }

        return timeText;
    }
}
