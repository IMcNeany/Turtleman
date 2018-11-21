using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSizeFlash : MonoBehaviour {

    public float lerp_speed;
    public Vector3 flash_size;
    private Vector3 default_size;
    public bool test = false;
    public bool pulsate = false;
    private float pulsate_timer = 1.0f;
    private float current_timer = 0.0f;

    void Start () {
        current_timer = pulsate_timer;
        default_size = gameObject.transform.localScale;

	}
	
	void Update () {
		if(gameObject.transform.localScale != default_size)
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, default_size, lerp_speed * Time.deltaTime);
        }
        if(test)
        {
            Flash();
            test = false;
        }
        if(pulsate)
        {
            current_timer -= 1 * Time.deltaTime;
            if(current_timer <= 0.0f)
            {
                Flash();
                current_timer = pulsate_timer;
            }
        }

	}

    void Flash()
    {
        gameObject.transform.localScale = flash_size;
    }
}
