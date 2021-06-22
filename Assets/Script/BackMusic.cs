using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackMusic : MonoBehaviour
{
    public AudioSource back;
    public Button backButton;
    public Text musicstatus;
    private bool musicflag = true;
    void Start()
    {
        back = this.GetComponent<AudioSource>();
        back.loop = true;  
        back.volume = 0.7f; // 设置音量最大，区间在0-1之间
        back.Play();
        backButton.onClick.AddListener(clickBackButton);    
    }

    public void clickBackButton()
    {
        if (musicflag == false)
        {
            back.volume = 0.7f;
            musicflag = true;
            musicstatus.text = "音乐：开";
            return;
        }
 
        if (musicflag == true)
        {
            back.volume = 0f;
            musicflag = false;
            musicstatus.text = "音乐：关";
            return;
        }
    }
}
