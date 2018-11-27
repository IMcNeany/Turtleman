using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text highScoreText;
    private UI_Manager eggScore;


    private void Start()
    {
        eggScore = GetComponent<UI_Manager>();
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        highScoreText.text = eggScore.EggCount.ToString();

        if (eggScore.EggCount > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", eggScore.EggCount);
            highScoreText.text = eggScore.EggCount.ToString();
        }


    }

}
