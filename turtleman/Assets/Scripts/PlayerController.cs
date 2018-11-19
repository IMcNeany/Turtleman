using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;

    void Start()
    {

    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal_1") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical_1") * Time.deltaTime * 2.0f;
        anim.SetFloat("Horizontal", (x * 10));
        anim.SetFloat("Vertical", (z * 10));
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
