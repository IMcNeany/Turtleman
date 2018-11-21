using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closerange : MonoBehaviour {

    private void OnTriggerEnter(Collider collided)
    {
        if (collided.tag == "Player")
        {
            GetComponentInParent<Wander>().setClose(true);
        }
    }

    private void OnTriggerExit(Collider collided)
    {
        if (collided.tag == "Player")
        {
            GetComponentInParent<Wander>().setClose(false);
        }
    }
}
