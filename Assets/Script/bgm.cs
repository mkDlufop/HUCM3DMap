using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgm : MonoBehaviour
{

    public AudioSource audioSource;
    private Button startButton;
    void Start()
    {
        // audioSource = transform.
        startButton = transform.GetComponent<Button>();
        startButton.onClick.AddListener(play_stop_music);
    }
    //开始、停止播放
    public void play_stop_music()
    {
        // Debug.Log("s");
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
    //暂停播放
    public void pause_music()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    //改变音量
    public void change_volume(float volume)
    {
        audioSource.volume = volume;
    }
}
