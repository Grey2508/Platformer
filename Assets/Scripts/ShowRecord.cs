using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour
{
    public Text NameText;
    public Text ScoreText;

    private void Start()
    {
        (string, int) highScore = Saver.Instance.GetHighScoreWithName();

        NameText.text = highScore.Item1;
        ScoreText.text = highScore.Item2.ToString();
    }
}
