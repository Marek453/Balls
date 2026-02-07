using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider SFX,Music,Main;
    public AudioMixer Mixer;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Sound_MAIN"))
        {
        SFX.value = 1;
        Music.value = 1;
        Main.value = 1;
        }
        else
        {
            SFX.value = PlayerPrefs.GetFloat("Sound_SFX");
            Music.value = PlayerPrefs.GetFloat("Sound_MUSIC");
            Main.value = PlayerPrefs.GetFloat("Sound_MAIN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Mixer.SetFloat("Volume",Main.value);
        Mixer.SetFloat("MusicVolume",Music.value);
        Mixer.SetFloat("SFXVolume",SFX.value);
        PlayerPrefs.SetFloat("Sound_SFX",SFX.value);
        PlayerPrefs.SetFloat("Sound_MUSIC",Music.value);
        PlayerPrefs.SetFloat("Sound_MAIN",Main.value);
    }
}
