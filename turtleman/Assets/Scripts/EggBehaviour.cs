using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour {

    float life = 0;
    float hatchTime = 2.0f;
    bool startHatch;
    public GameObject particleSystem;
    public GameObject turtle;
    MeshRenderer eggRenderer;
	// Use this for initialization
	void Start () {
        startHatch = true;
        eggRenderer = gameObject.GetComponent<MeshRenderer>();

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
            eggRenderer.enabled = false;
            //spawn enemy
            Instantiate(turtle, gameObject.transform.position, gameObject.transform.rotation);
            //delete this

            Destroy(gameObject,3.0f);

        }
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerController>())
        {
            //add one to egg collection


            Destroy(gameObject, 0.1f);
        }
    }


}
