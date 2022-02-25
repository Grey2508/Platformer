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
}
