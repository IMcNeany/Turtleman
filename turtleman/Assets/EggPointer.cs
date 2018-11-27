using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] egg = GameObject.FindGameObjectsWithTag("Egg");
        if (egg != null)
        {
            GameObject lookAtEgg = egg[0];
            for(int i = 0; i < egg.Length; i++)
            {
                if(Vector3.Distance(gameObject.transform.position, egg[i].transform.position) < Vector3.Distance(gameObject.transform.position, lookAtEgg.transform.position))
                {
                    lookAtEgg = egg[i];
                }
            }
            gameObject.transform.LookAt(lookAtEgg.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
	}
}
