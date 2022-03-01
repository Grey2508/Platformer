using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioListener AudioListener;
    public Image SoundIconUI;

    public GameObject MenuButton;
    public GameObject MenuWindow;

    private void Start()
    {
        SetSoundState();
    }

    public void StartGame()
    {
        ScoreCounter.Instance.ResetCounter();
        SceneSwitcher.Instance.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        PlayerHealthCounter.Instance.Destroy();

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

        PlayerHealthCounter.Instance.Destroy();

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

    public void OpenMenuWindow()
    {
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);

        Time.timeScale = 0;
    }

    public void CloseMenuWindow()
    {
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);

        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        ScoreCounter.Instance.ResetSceneScore();
        SceneSwitcher.Instance.ReloadCurrentScene();
    }
}