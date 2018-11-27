using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCave : MonoBehaviour
{
    private UI_Manager ui;
    private GameObject player;
    private bool can_exit = false;

    private void Start()
    {
        ui = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(ui.EggCount >= 1)
        {
            can_exit = true;
        }
        else
        {
            can_exit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == player.tag && can_exit)
        {
            //Exit to whatever stage
            Debug.Log("Exit Stage with " + ui.EggCount + " egg(s).");
            SceneManager.LoadScene(2);
        }
    }
}
