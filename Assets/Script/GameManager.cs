using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 单例模式，保证了全局有且只有一个实例对象，保证自动地初始化该对象，使得程序在任何时候任何地方都可以访问、获取该对象。
// 主要用来存储一些公用的方法或者公用的数据。
public class GameManager
{
    private static GameManager _Instance; // 实例化一个对象
    public static GameManager Instance // 获取该对象的方法
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = new GameManager();
            }
            return _Instance;
        }
    }

    // 切换场景
    public void LoadScene(string sceneName)
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // 获取当前场景索引后加1
        SceneManager.LoadScene(sceneName);
    }
}
