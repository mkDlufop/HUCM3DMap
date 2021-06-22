using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource musicSource; // 声明音频来源
    public void MusicStart(string name)
    {
        AudioClip music = (AudioClip)Resources.Load(name);
        musicSource.clip = music;
        musicSource.Play();
    }
    public void MusicStop()
    {
        musicSource.Stop();
    }
}
