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
        PlayerHealthCounter.Instance.SetActive(false);

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
    }
}
