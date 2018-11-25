using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 10.0f;
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float x = 0.0f;
    public float y = 0.0f;
    public bool testCam;
    public float lerpSpeed = 2.0f;
    private Vector3 velocity = Vector3.zero;
    public bool isRight = false;
    public Vector3 forward;
    public Vector3 right;

    // Use this for initialization
    void Start()
    {
        if(!target)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        if (isRight)
        {
            x = angles.y + 90;
        }

    }

    void FixedUpdate()
    {
        if (!testCam)
        {
            float tempDistance = distance;
            x += Input.GetAxis("Aim_Horizontal_1") * xSpeed * tempDistance * 0.02f;
            y -= Input.GetAxis("Aim_Vertical_1") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            RaycastHit hit;
            Vector3 hitPosition = transform.position - transform.forward;

            if (Physics.Linecast(target.position, hitPosition, out hit))
            {
                if (hit.transform != target.transform)
                {
                    tempDistance = hit.distance;
                    Debug.Log(hit.transform.name);
                }
            }
            if (tempDistance > distance)
            {
                tempDistance = distance;
            }

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -tempDistance);
            Vector3 position = rotation * negDistance + target.position;
            position.y = 3;


            transform.rotation = rotation;
            transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, lerpSpeed);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}