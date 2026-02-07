using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioArrayLoader : MonoBehaviour
{
    public string folderPath;
    public string delChar;
    public static AudioArrayLoader instance;
    public List<AudioClip> audioClips;

    public bool isFinded;

    private void Awake()
    {
        instance = this;
        StartCoroutine(_Start());
    }

    IEnumerator _Start()
    {
        string path = Application.dataPath + "/" + folderPath;
        WWW www = new WWW(path);

        yield return www;

        string[] files = System.IO.Directory.GetFiles(path);

        for (int i = 0; i < files.Length; i++)
        {
            if(files[i].EndsWith(".mp3"))
            {
            string filePath = "file:///" + files[i];
            WWW audioLoader = new WWW(filePath);
            yield return audioLoader;
            string newname = files[i].Replace(path, "");
            string newnew = newname.Replace(delChar, "");
            AudioClip clip = audioLoader.GetAudioClipCompressed();
            clip.name = newnew;
            audioClips.Add(clip);
            }
            isFinded = true;
        }
    }
}