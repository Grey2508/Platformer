using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioListener AudioListener;
    public Image SoundIconUI;

    private void Awake()
    {
        SetSoundState();
    }

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

    public void SwitchSound()
    {
        SoundState.Instance.SwitchSoundState();

        SetSoundState();
    }

    private void SetSoundState()
    {
        AudioListener.enabled = SoundState.Instance.IsSoundOn;

        if (SoundIconUI != null)
            SoundIconUI.sprite = SoundState.Instance.GetCurrentIcon();
    }
}