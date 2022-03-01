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

    public void ToResultScreenWithDelay(float delay)
    {
        StartCoroutine(ToResultScreen(delay));
    }

    public IEnumerator ToResultScreen(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneSwitcher.Instance.ToResultScreen();
    }
}