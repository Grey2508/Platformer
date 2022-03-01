using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;

    private int _currentSceneIndex = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1;

        _currentSceneIndex = sceneIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ToResultScreen()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void ReloadCurrentScene()
    {
        LoadScene(_currentSceneIndex);
    }
}
