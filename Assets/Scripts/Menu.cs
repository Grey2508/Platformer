using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        ScoreCounter.Instance.Reset();
        SceneSwitcher.Instance.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneSwitcher.Instance.LoadScene(0);
    }

    public void SaveHighScore(string name)
    {
        Saver.Instance.SetHighScore(name, ScoreCounter.Instance.TotalScore);
    }
    

    public void ShowHighScore()
    {
        Debug.Log(PlayerPrefs.GetString("HighScore"));
    }

    
}
