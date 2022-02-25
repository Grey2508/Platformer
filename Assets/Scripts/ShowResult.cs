using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Text TotalScoreText;

    private void Start()
    {
        TotalScoreText.text = ScoreCounter.Instance.TotalScore.ToString();
    }
}
