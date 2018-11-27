﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Animator anim;
    public Vector3 controllerPos;
    public GameObject uiManager;
    //private UI_Manager healthRef;
    private SceneController gameOver;
    
    public int health;
    public float Movespeed;
    public float RotateSpeed;
    bool canMove = true;
    public float footstep_delay = 0.25f;
    private float current_delay = 0.0f;
    public AudioSource audio;
    void Start()
    {
        health = 3;
        //healthRef = gameObject.GetComponent<UI_Manager>();
        gameOver = gameObject.GetComponent<SceneController>();
        PlayerPrefs.SetInt("HighScore", 0);
    }

    void Update()
    {
        if(health > 0)
        {
            controllerPos.x = Input.GetAxis("Horizontal_1") * Time.deltaTime * Movespeed;
            controllerPos.z = Input.GetAxis("Vertical_1") * Time.deltaTime * RotateSpeed;
        }
        
        
        //controllerPos.Normalize();

        if(Input.GetButton("X_1"))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("Horizontal", controllerPos.x);
        anim.SetFloat("Vertical", controllerPos.z);

        if (controllerPos.z > 0.009f)
        {
            //Debug.Log("running");
            //when player is moving
            anim.SetBool("RunningBackwards", false);
            anim.SetBool("Running", true);
            current_delay -= 1 * Time.deltaTime;
            if(current_delay <= 0.0f)
            {
                audio.Play();
                current_delay = footstep_delay;
            }
        }
        else if (controllerPos.z < -0.01f)
        {
            anim.SetBool("Running", true);
            current_delay -= 1 * Time.deltaTime;
            if (current_delay <= 0.0f)
            {
                audio.Play();
                current_delay = footstep_delay;
            }
            anim.SetBool("RunningBackwards", true);
        }
        else if (controllerPos.z == 0)
        {
            anim.SetBool("RunningBackwards", false);
            //comes to a stop
            anim.SetBool("Running", false);
        }

        if (health <= 0)
        {
            PlayerPrefs.SetInt("HighScore", uiManager.GetComponent<UI_Manager>().EggCount);
            anim.SetBool("Death", true);
            //gameOver.GameOver();
            StartCoroutine(endGame());
        }

        //anim.SetFloat("Horizontal", (x * 10));
        //anim.SetFloat("Vertical", (z * 10));
        //transform.Rotate(0, controllerPos.x , 0);
        // transform.Translate(0, 0, controllerPos.z);
        // healthRef.Health = 3;
        if (health > 0)
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            transform.position += camera.transform.forward * controllerPos.z;
            transform.localRotation = camera.transform.localRotation;
        }
        // transform.LookAt(camera.transform.localRotation.eulerAngles);
       
        //transform.Translate(transform.position + camera.transform.forward * controllerPos.z);
        //transform.Rotate(0, camera.transform.rotation.x, 0);
    }

    public void setHealth(int healthr)
    {
        health = healthr;
    }

    public int getHealth()
    {
        return health;
    }

    private IEnumerator endGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);


    }
}
