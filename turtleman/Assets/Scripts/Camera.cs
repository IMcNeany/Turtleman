using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    public GameObject player;
    public float CameraHeight;


    private Vector3 offset;        
    void Start()
    {
        offset = new Vector3(0,CameraHeight ,transform.position.z - player.transform.position.z);
    }
    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}