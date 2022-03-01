using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text _scoreCountText;

    private int _scoreAtBeginLevel;

    public int TotalScore
    {
        get;
        private set;
    }

    public static ScoreCounter Instance;

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

    private void OnChangeScene(Scene Scene, LoadSceneMode loadSceneMode)
    {
        _scoreCountText = GameObject.FindWithTag("ScoreCountText")?.GetComponent<Text>();

        _scoreAtBeginLevel = TotalScore;

        if (_scoreCountText)
            _scoreCountText.text = TotalScore.ToString();
    }

    public void AddScore(int ScoreCount)
    {
        TotalScore += ScoreCount;

        if (_scoreCountText)
            _scoreCountText.text = TotalScore.ToString();
    }

    public void ResetCounter()
    {
        TotalScore = 0;
    }

    public void ResetSceneScore()
    {
        TotalScore = _scoreAtBeginLevel;
    }
}
