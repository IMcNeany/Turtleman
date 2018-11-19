using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour {

    float life = 0;
    float hatchTime = 2.0f;
    float speed = 1.0f;
    float strength = 1.0f;
    bool startHatch;
    public GameObject particleSystem;
    public GameObject turtle;
    MeshRenderer eggRenderer;
    UI_Manager ui_manager;
	// Use this for initialization
	void Start () {
        startHatch = true;
        eggRenderer = gameObject.GetComponent<MeshRenderer>();
        ui_manager = gameObject.GetComponent<UI_Manager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (startHatch)
        {
            life += Time.deltaTime;
            transform.rotation = new Quaternion(Mathf.Sin(Time.time * 5.0f) * 0.15f, transform.rotation.y, transform.rotation.z,1.0f);
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
            ui_manager.EggCount = ui_manager.EggCount += 1;

            Destroy(gameObject, 0.1f);
        }
    }


}
