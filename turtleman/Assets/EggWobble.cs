﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggWobble : MonoBehaviour
{

    private bool shake = false;
    [SerializeField] private float shakeAmount = 5;
    // Update is called once per frame
    void Update()
    {
        if (shake == true)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }

    }

    public void Shake()
    {
        StartCoroutine("ShakeMe");
    }

    IEnumerator ShakeMe()
    {
        Vector3 originalPos = transform.position;
        if (shake == false)
        {
            shake = true;
        }

        yield return new WaitForSeconds(0.25f);

        shake = false;
        transform.position = originalPos;
    }
}
