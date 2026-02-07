using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Update()
    {
        if(AudioArrayLoader.instance.isFinded)
        {
        if(GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = AudioArrayLoader.instance.audioClips[Random.Range(0, AudioArrayLoader.instance.audioClips.Count)];
            GetComponent<AudioSource>().Play();
        }
        }
    }
}
