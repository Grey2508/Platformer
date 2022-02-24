using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private static Text _scoreCountText;

    public static int TotalScore
    {
        get;
        private set;
    }

    private static bool created = false;

    void Awake()
    {
        if (created)
            return;

        DontDestroyOnLoad(gameObject);
        created = true;
    }

    public static void AddScore(int ScoreCount)
    {
        TotalScore += ScoreCount;

        if (_scoreCountText)
            _scoreCountText.text = TotalScore.ToString();
    }

    private void OnLevelWasLoaded()
    {
        _scoreCountText = GameObject.FindWithTag("ScoreCountText").GetComponent<Text>();
        _scoreCountText.text = TotalScore.ToString();
    }

    public static void Reset()
    {
        TotalScore = 0;
    }
}
