using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToStartScene : MonoBehaviour
{
    private Button startButton;
    void Start()
    {
        startButton = transform.GetComponent<Button>();
        startButton.onClick.AddListener(ClickStartButton);
    }

    private void ClickStartButton() {
        GameManager.Instance.LoadScene("StartPage");
    }
}
