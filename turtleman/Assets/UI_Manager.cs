﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Health Values")]
    public int Health = 3;
    public Image HP1;
    public Image HP2;
    public Image HP3;

    [Header("Score Values")]
    public Text ScoreText;
    public int EggCount = 0;

    //[Header("Timer Values")]
    //[SerializeField]
    //private Text TimerText;
    //[SerializeField] private float seconds = 100.0f; //How many seconds
    //private float timer;
    //private bool canCount = true;
    //private bool doOnce = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UIStuff();
        //GameTimer();
        //FormatTimer();
    }

    private void UIStuff()
    {
        switch (Health)
        {
            case 0:
                HP1.enabled = false;
                HP2.enabled = false;
                HP3.enabled = false;
                break;
            case 1:
                HP1.enabled = true;
                HP2.enabled = false;
                HP3.enabled = false;
                break;
            case 2:
                HP1.enabled = true;
                HP2.enabled = true;
                HP3.enabled = false;
                break;
            case 3:
                HP1.enabled = true;
                HP2.enabled = true;
                HP3.enabled = true;
                break;
        }
        ScoreText.text = "" + EggCount;
    }

    //private void GameTimer()
    //{
    //    if (timer >= 0.0f && canCount)
    //    {
    //        timer -= 1 * Time.deltaTime;
    //        TimerText.text = timer.ToString("F");
    //    }
    //    else if (timer <= 0.0f && !doOnce)
    //    {
    //        canCount = false;
    //        doOnce = true;
    //        TimerText.text = "0.00";
    //        timer = 0.0f;
    //    }
    //}

    //private void FormatTimer() //Changes seconds to minutes
    //{
    //    string minutes = Mathf.Floor(timer / 60).ToString("00");
    //    string seconds = (timer % 60).ToString("00");
    //    TimerText.text = "Time Left: " + minutes + " : " + seconds;
    //}
}
