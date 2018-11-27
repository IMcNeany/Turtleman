using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioScript : MonoBehaviour {


    public AudioSource audio1;
    public PlayerController player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.chase_amount == 0)
        {
            audio1.Stop();
        }

        if (player.chase_amount > 0 && !audio1.isPlaying) {
            audio1.Play();
        }
	}
}
