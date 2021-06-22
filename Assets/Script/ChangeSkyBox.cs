using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering;

public class ChangeSkyBox : MonoBehaviour
{
    public Material[] mats;
    int index = 0;

    public GameObject DirectionalLight;
    private Light light;
	private float timer = 0;

    public Button skyButton;
    public Text skystatus;

    void Update()
    {
        skyButton = skyButton.GetComponent<Button>();
        skyButton.onClick.AddListener(ChangeSkyBoxs);
        light = DirectionalLight.GetComponent<Light>();
        if (Input.GetKey(KeyCode.Q))
            // InvokeRepeating("ChangeSkyBoxs", 0, 0.001f); // 每隔0.001s换一次天空盒
            ChangeSkyBoxs();
    }

    private void ChangeSkyBoxs() {
        index++;
        index %= mats.Length;
        RenderSettings.skybox = mats[index]; // 改变天空盒(RenderSettins渲染设置)
        if (index == 0)
        {
            skystatus.text = "白天";
            while(timer <= 1) {
                timer += Time.deltaTime; // 如果要控制在指定时间内变换，在Time.deltatime上乘“1/指定时间”即可
                light.intensity = Mathf.Lerp(0,1,timer); // 使用线性插值和timer实现渐变
            }
        } else if (index == 1)
        {
            skystatus.text = "夜晚";
            while(timer >= 0) {
                timer -= Time.deltaTime;
                light.intensity = Mathf.Lerp(0,1,timer);
            }
        } else
        {} 
    }
}
