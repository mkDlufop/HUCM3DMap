using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour
{
    public Button tsgButton;
    public Button sylButton;
    public Button kylButton;
    public Button sslButton;
    public Button xyhButton;
    public Button activityButton;
    public Button linkButton;
    public Button backButton;

    public GameObject tsg;
    public GameObject syl;
    public GameObject kyl;
    public GameObject ssl;
    public GameObject xyh;
    public GameObject activity;
    // private bool tsgflag = true;
    // private bool sylflag = false;
    // private bool kylflag = false;
    // private bool sslflag = false;
    // private bool xyhflag = false;
    
    void Start()
    {
        tsgButton = transform.FindChild("button_tsg").GetComponent<Button>();
        tsgButton.onClick.AddListener(clickTsgButton);
        sylButton = transform.FindChild("button_syl").GetComponent<Button>();
        sylButton.onClick.AddListener(clickSylButton);
        kylButton = transform.FindChild("button_kyl").GetComponent<Button>();
        kylButton.onClick.AddListener(clickKylButton);
        sslButton = transform.FindChild("button_ssl").GetComponent<Button>();
        sslButton.onClick.AddListener(clickSslButton);
        xyhButton = transform.FindChild("button_xyh").GetComponent<Button>();
        xyhButton.onClick.AddListener(clickXyhButton);
        activityButton = transform.FindChild("button_activity").GetComponent<Button>();
        activityButton.onClick.AddListener(clickActivityButton);
        linkButton = transform.FindChild("button_link").GetComponent<Button>();
        linkButton.onClick.AddListener(clickLinkButton);
        backButton = transform.FindChild("button_back").GetComponent<Button>();
        backButton.onClick.AddListener(clickBackButton);
    }

    public void clickTsgButton()
    {
        tsg.SetActive(true);
        syl.SetActive(false);
        kyl.SetActive(false);
        ssl.SetActive(false);
        xyh.SetActive(false);
        activity.SetActive(false);
        return;
    }

    public void clickSylButton()
    {
        tsg.SetActive(false);
        syl.SetActive(true);
        kyl.SetActive(false);
        ssl.SetActive(false);
        xyh.SetActive(false);
        activity.SetActive(false);
        return;
    }

    public void clickKylButton()
    {
        tsg.SetActive(false);
        syl.SetActive(false);
        kyl.SetActive(true);
        ssl.SetActive(false);
        xyh.SetActive(false);
        activity.SetActive(false);
        return;
    }

    public void clickSslButton()
    {
        tsg.SetActive(false);
        syl.SetActive(false);
        kyl.SetActive(false);
        ssl.SetActive(true);
        xyh.SetActive(false);
        activity.SetActive(false);
        return;
    }

    public void clickXyhButton()
    {
        tsg.SetActive(false);
        syl.SetActive(false);
        kyl.SetActive(false);
        ssl.SetActive(false);
        xyh.SetActive(true);
        activity.SetActive(false);
        return;
    }

    public void clickActivityButton()
    {
        tsg.SetActive(false);
        syl.SetActive(false);
        kyl.SetActive(false);
        ssl.SetActive(false);
        xyh.SetActive(false);
        activity.SetActive(true);
        return;
    }

    public void clickLinkButton()
    {
        Application.OpenURL("https://news.hnucm.edu.cn/wszt.htm");
    }

    public void clickBackButton()
    {
        GameManager.Instance.LoadScene("StartPage");
    }
}
