using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    static public AudioSource audio;
    static public bool isPlaying;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        //audio.Play();
    }
    static public void stop()
    {
        audio.Stop();
        isPlaying = false;
    }
    static public void play()
    {
        audio.Play();
        isPlaying = true;
    }
}
