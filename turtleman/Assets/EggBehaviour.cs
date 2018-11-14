using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour {

    float life = 0;
    float hatchTime = 2.0f;
    bool startHatch;
    public GameObject particleSystem;
    public GameObject turtle;
	// Use this for initialization
	void Start () {
        startHatch = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (startHatch)
        {
            life += Time.deltaTime;
        }
        if(life > hatchTime)
        {
            //particles
            particleSystem.SetActive(true);
            life = 0;
            startHatch = false;

            //spawn enemy
            Instantiate(turtle, gameObject.transform.position, gameObject.transform.rotation);
            //delete this

            Destroy(gameObject,2.0f);

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //add one to egg collection

        Destroy(gameObject, 0.1f);
    }


}
