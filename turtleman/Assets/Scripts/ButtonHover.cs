using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour {

    public AudioSource audioSource1;
    public AudioClip hover;
    public AudioClip click;

    // Use this for initialization
    public void HoverSound()
    {
        audioSource1.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        audioSource1.PlayOneShot(click);
    }
}
