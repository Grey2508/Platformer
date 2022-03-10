using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;
    public GameObject LoadScreen;

    private int _currentSceneIndex = 0;

    void Awake()
    {
        SceneManager.sceneLoaded += OnChangeScene;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnChangeScene(Scene arg0, LoadSceneMode arg1)
    {
        LoadScreen.SetActive(false);

        Time.timeScale = 1;
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 0;
        LoadScreen.SetActive(true);

        _currentSceneIndex = sceneIndex;
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ToResultScreen()
    {
        LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void ReloadCurrentScene()
    {
        LoadScene(_currentSceneIndex);
    }
}
