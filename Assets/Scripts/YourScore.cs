using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YourScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Score;

    [SerializeField]
    private TMP_Text HighScore;

    public float score = 0f;
    public float highscore = 0f;

    private void Start()
    {
        AudioManager.instance.PlaySFX("GameOver");
        score = PlayerController.instance.topScore;
        highscore = PlayerController.instance.topHighScore;

        Score.text = "Your Score: " + Mathf.Round(score).ToString();
        HighScore.text = "High Score: " + Mathf.Round(highscore).ToString();
    }
  
}
