using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Health Values")]
    public int Health = 3;
    public Image HP1;
    public ModelSizeFlash HP1Flashl;
    public ModelSizeFlash HP1Flash2;
    public ModelSizeFlash HP1Flash3;
    public Image HP2;
    public Image HP3;
    public Image redOverLay;

    [Header("Score Values")]
    public Text ScoreText;
    public Text highScoreText;
    public int EggCount = 0;

    public Text Assistance;
    DataPersistance gm;




    GameObject player;
    PlayerController playercon;

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
        player = GameObject.FindWithTag("Player");
        playercon = player.GetComponent<PlayerController>();
        HP1Flashl = HP1.GetComponent<ModelSizeFlash>();
        HP1Flash2 = HP2.GetComponent<ModelSizeFlash>();
        HP1Flash3 = HP3.GetComponent<ModelSizeFlash>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<DataPersistance>();
        HP1Flashl.pulsate = false;
        HP1Flash2.pulsate = false;
        HP1Flash3.pulsate = false;
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
        switch (playercon.getHealth())
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
                HP1Flash2.pulsate = false;
                HP1Flash3.pulsate = false;
                HP1Flashl.pulsate = true;
                break;
            case 2:
                HP1.enabled = true;
                HP2.enabled = true;
                HP3.enabled = false;
                HP1Flashl.pulsate = false;
                HP1Flash2.pulsate = true;
                HP1Flash3.pulsate = false;
                break;
            case 3:
                HP1.enabled = true;
                HP2.enabled = true;
                HP3.enabled = true;
                HP1Flash3.pulsate = true;
                HP1Flashl.pulsate = false;
                HP1Flash2.pulsate = false;
                break;
        }
        ScoreText.text = "" + EggCount;
        gm.setPlayerScore(EggCount);
        //StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Assistance.gameObject.SetActive(false);
       
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
