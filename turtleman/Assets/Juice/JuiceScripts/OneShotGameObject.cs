using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotGameObject : MonoBehaviour {

    public float life_time = 1.0f;
    private float current_time;
	// Use this for initialization
	void Start () {
        current_time = life_time;
	}
	
	// Update is called once per frame
	void Update () {
        current_time -= 1 * Time.deltaTime;
        if(current_time <= 0.0f)
        {
            Destroy(gameObject);
        }
	}
}
