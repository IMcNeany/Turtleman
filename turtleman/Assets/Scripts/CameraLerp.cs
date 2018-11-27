using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CameraLerp : MonoBehaviour {

    public Transform target;
    public Transform startPos;
    public float travelTIme;
    public Transform egg;
    Vector3 start;
    Vector3 end;
    float timer;

    // Use this for initialization
    void Start ()
    {
        start = startPos.position;
        end = target.position;
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(start, end, timer / travelTIme);
        transform.LookAt(egg);
        StartCoroutine(CutsceneDelay());

    }
        private IEnumerator CutsceneDelay()
        {
            yield return new WaitForSeconds(15);
        SceneManager.LoadScene(2);


    }
}
