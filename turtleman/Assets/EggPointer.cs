using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject egg = GameObject.Find("Egg(Clone)");
        if (egg != null)
        {
            gameObject.transform.LookAt(egg.transform);
        }
	}
}
