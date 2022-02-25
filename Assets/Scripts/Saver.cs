using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver Instance;

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

    public void SetHighScore(string name, int value)
    {
        PlayerPrefs.SetString("HighScore", $"{name}#{value}");
    }

    public (string, int) GetHighScoreWithName()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
            return ("", 0);

        string[] s = PlayerPrefs.GetString("HighScore").Split('#');
        int score = int.TryParse(s[1], out int result) ? result : 0;

        return (s[0], score);
    }

    public int GetHighScore()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
            return 0;

        string[] s = PlayerPrefs.GetString("HighScore").Split('#');
        int score = int.TryParse(s[1], out int result) ? result : 0;

        return score;
    }
}
