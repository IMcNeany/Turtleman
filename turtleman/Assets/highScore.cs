using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text hiScoreText;
    private UI_Manager eggScore;
    public int newEggScore = 10;

    private void Start()
    {
        eggScore = GetComponent<UI_Manager>();
    }

    private void Update()
    {

    }
}
