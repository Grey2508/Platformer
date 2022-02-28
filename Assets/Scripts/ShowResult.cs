using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Text TotalScoreText;
    public Menu Menu;

    public GameObject EnterNameArea;
    public Text ScoreCountText;

    public AudioSource MusicWithRecord;
    public AudioSource MusicWithoutRecord;

    private void Start()
    {
        int totalScore = ScoreCounter.Instance.TotalScore;
        TotalScoreText.text = totalScore.ToString();

        if (totalScore >= Saver.Instance.GetHighScore())
        {
            ScoreCountText.text = totalScore.ToString();
            EnterNameArea.SetActive(true);
            MusicWithRecord.Play();
        }
        else
            MusicWithoutRecord.Play();

        PlayerHealthCounter.Instance.Destroy();
    }
}
