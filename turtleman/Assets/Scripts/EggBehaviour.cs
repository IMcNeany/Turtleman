using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour
{

    float life = 0;
    public float hatchTime = 10.0f;
    float speed = 1.0f;
    float strength = 1.0f;
    bool startHatch;

    public GameObject hatch_audio;
    public GameObject pickup_audio;
    public GameObject particleSystem;
    public GameObject turtle;
    MeshRenderer eggRenderer;
    UI_Manager ui_manager;
    EggWobble cltObject;
    // Use this for initialization
    void Start()
    {
        startHatch = true;
        eggRenderer = gameObject.GetComponent<MeshRenderer>();
        if (GameObject.Find("UI_Manager"))
        {
            ui_manager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        }
        if (GameObject.Find("EggImage"))
        {
            cltObject = GameObject.Find("EggImage").GetComponent<EggWobble>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startHatch && life < (hatchTime - 5))
        {
            life += Time.deltaTime;
            transform.rotation = new Quaternion(Mathf.Sin(Time.time * 5.0f) * 0.15f, transform.rotation.y, transform.rotation.z, 1.0f);
        }
        else
        {
            life += Time.deltaTime;
            transform.rotation = new Quaternion(Mathf.Sin(Time.time * 8.0f) * 0.1f, transform.rotation.y, Mathf.Sin(Time.time * 8.0f) * 0.1f, 1.0f);
        }
        if (life > hatchTime)
        {
            //particles
            particleSystem.SetActive(true);
            life = 0;
            startHatch = false;
            eggRenderer.enabled = false;
            //spawn enemy

            //delete this

            Destroy(gameObject, 3.0f);
            Instantiate(turtle, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(hatch_audio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerController>())
        {
            //add one to egg collection
            Debug.Log("Collected Egg");
            ui_manager.EggCount = ui_manager.EggCount += 1;
            UIShake();
            Instantiate(pickup_audio);
            Destroy(gameObject, 0.1f);
        }
    }
    private void UIShake()
    {
        cltObject.GetComponent<EggWobble>().Shake();
    }

    public void SetTimeToHatch(float newTimer)
    {
        hatchTime = newTimer;
    }
}
