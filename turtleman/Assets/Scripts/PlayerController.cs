﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;
    public Vector3 controllerPos;
    private UI_Manager healthRef;
    public float Movespeed;
    public float RotateSpeed;
    void Start()
    {
        healthRef = gameObject.GetComponent<UI_Manager>();
    }

    void Update()
    {
        controllerPos.x = Input.GetAxis("Horizontal_1") * Time.deltaTime * Movespeed;
        controllerPos.z = Input.GetAxis("Vertical_1") * Time.deltaTime * RotateSpeed;
        
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
            Debug.Log("running");
            //when player is moving
            anim.SetBool("RunningBackwards", false);
            anim.SetBool("Running", true);
        }
        else if (controllerPos.z < -0.01f)
        {
            anim.SetBool("Running", true);
            anim.SetBool("RunningBackwards", true);
        }
        else if (controllerPos.z == 0)
        {
            anim.SetBool("RunningBackwards", false);
            //comes to a stop
            anim.SetBool("Running", false);
        }



        //anim.SetFloat("Horizontal", (x * 10));
        //anim.SetFloat("Vertical", (z * 10));
        //transform.Rotate(0, controllerPos.x , 0);
       // transform.Translate(0, 0, controllerPos.z);
       // healthRef.Health = 3;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.position += camera.transform.forward * controllerPos.z;
        // transform.LookAt(camera.transform.localRotation.eulerAngles);
        transform.localRotation = camera.transform.localRotation;
        //transform.Translate(transform.position + camera.transform.forward * controllerPos.z);
        //transform.Rotate(0, camera.transform.rotation.x, 0);
    }
}
