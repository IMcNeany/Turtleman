using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAquire : MonoBehaviour {

	private SphereCollider range;
	private Wander parent;
	void Start () {
		range = GetComponent<SphereCollider>();
		parent = GetComponentInParent<Wander>();
	}

	void Update (){
		range.radius = parent.acquisitionRadius;
	}

	private void OnTriggerEnter(Collider collided)
    {
        if (collided.tag == "Player")
        {
            parent.playerAquired(collided.gameObject);
        }
    }

	private void OnTriggerExit(Collider collided)
    {
        if (collided.tag == "Player")
        {
          parent.deAquire();
        }
    }
}
