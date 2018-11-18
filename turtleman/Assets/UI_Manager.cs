using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Health Values")]
    public Text HealthText;

    [Header("Timer Values")]
    [SerializeField] private Text TimerText;
    [SerializeField] private float seconds = 100.0f; //How many seconds
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    [Header("Score Values")]
    public Text ScoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UIStuff();
        GameTimer();
        FormatTimer();
    }

    private void UIStuff()
    {
        HealthText.text = "x " + 3 /*health value*/;

        ScoreText.text = "Egg Count: " + 100 /*Egg*/;

    }

    private void GameTimer()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= 1 * Time.deltaTime;
            TimerText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            TimerText.text = "0.00";
            timer = 0.0f;
        }
    }

    private void FormatTimer() //Changes seconds to minutes
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        TimerText.text = "Time Left: " + minutes + " : " + seconds;
    }
}
