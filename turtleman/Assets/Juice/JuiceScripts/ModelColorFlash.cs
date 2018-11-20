using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelColorFlash : MonoBehaviour {

    public Color flash_color;
    public float lerp_speed;
    private Renderer model_renderer;
    private Color default_color;
    public bool test = false;
	// Use this for initialization
	void Start () {
        model_renderer = gameObject.GetComponent<Renderer>();
        default_color = model_renderer.material.color;
    }
	
	// Update is called once per frame
	void Update () {
		if(model_renderer.material.color != default_color)
        {
            model_renderer.material.color = Color.Lerp(model_renderer.material.color, default_color, lerp_speed* Time.deltaTime);
        }
        if(test)
        {
            Flash();
            test = false;
        }
	}

    void Flash()
    {
        model_renderer.material.color = flash_color;
    }
}
