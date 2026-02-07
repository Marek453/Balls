using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_Text Name,Lenght;
    public Image prefab;
    private Image[] cubes;
    public int numberOfObjects = 64;
    public float maxScale = 50f;
    public float updateSpeed = 0.5f;
    private float[] samples;

    void Start()
    {
        cubes = new Image[numberOfObjects];
        samples = new float[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            cubes[i] = Instantiate(prefab, transform.position, Quaternion.identity, transform);
            cubes[i].transform.position = new Vector2(base.transform.position.x + i, base.transform.position.y);
        }
    }

    void Update()
    {
        if(AudioArrayLoader.instance.isFinded)
        {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        Name.text ="Now Playing:" + "\n" + audioSource.clip.name;
        Lenght.text = audioSource.time.ToString("0:00") + "/" + audioSource.clip.length.ToString("0:00");
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = cubes[i].transform.localScale;
           // previousScale.x = Mathf.Lerp(previousScale.x , samples[i] * maxScale, Time.deltaTime / updateSpeed);
            previousScale.y = Mathf.Lerp(previousScale.y , samples[i] * maxScale, Time.deltaTime / updateSpeed);
            cubes[i].transform.localScale = previousScale;
        }
        }
    }
}
