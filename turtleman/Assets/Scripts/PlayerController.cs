using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;
    public Vector3 controllerPos;
    public float Movespeed;
    public float RotateSpeed;
    void Start()
    {

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
            anim.SetBool("Running", true);
        }
        if(controllerPos.z == 0)
        {
            Debug.Log("Standing still");
            //comes to a stop
            anim.SetBool("Running", false);
        }
      

        //anim.SetFloat("Horizontal", (x * 10));
        //anim.SetFloat("Vertical", (z * 10));
        transform.Rotate(0, controllerPos.x, 0);
        transform.Translate(0, 0, controllerPos.z);

       

    }
}
