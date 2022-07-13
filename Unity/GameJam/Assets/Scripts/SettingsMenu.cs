using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private float volume;

    void Start()
    {
        volume = PlayerPrefs.GetFloat("volume", 0.5f); //returns 0.5f if no PlayerPref exists

        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        volumeSlider.value = volume;
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
