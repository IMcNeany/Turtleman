using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSizeFlash : MonoBehaviour {

    public float lerp_speed;
    public Vector3 flash_size;
    private Vector3 default_size;
    public bool test = false;
    // Use this for initialization
    void Start () {
        default_size = gameObject.transform.localScale;

	}
	
	// Update is called once per frame
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
	}

    void Flash()
    {
        gameObject.transform.localScale = flash_size;
    }
}
