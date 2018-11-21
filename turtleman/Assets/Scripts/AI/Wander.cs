using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float maxWaitTime = 5.0f;
    public float baseSpeed = 5.0f;
    public float groundOffset = 0.15f;

    private float speed = 5.0f;
    public float acquisitionRadius = 5.0f;
    private List<Node> path;
    private int pathIndex = 0;
    private bool waitingForPath = false;
    private bool closeRange = false;
    private GameObject player;

    private Grid grid;
    private Animator anim;
    private Rigidbody rb;

    public void setClose(bool b) {
       //closeRange = b;
    }

    public void playerAquired(GameObject player){
        this.player = player;
        path = null;
        pathIndex = 0;
        speed = baseSpeed + 2.0f;
    }

    public void deAquire(){
        player = null;
        path = null;
        pathIndex = 0;
        speed = baseSpeed;
    }

	// Use this for initialization
	void Start () {
        grid = GameObject.FindGameObjectWithTag("WaypointGrid").GetComponent<Grid>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (closeRange){
            Vector3 target = player.transform.position;
            target.y = groundOffset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            
        } else if(path != null && path.Count > 0){
            Vector3 target = path[pathIndex].transform.position;
            target.y = groundOffset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(transform.position - target);
            anim.SetBool("moving", true);
            if (roundVec(transform.position, 0.2f) == roundVec(target, 0.2f)){
                pathIndex++;

                if(pathIndex >= path.Count)
                {
                    path = null;
                    pathIndex = 0;
                }
            }  
        } else if(!waitingForPath){
            anim.SetBool("moving", false);
            if(player == null){
                Invoke("findNewRandomPath", Random.Range(1.0f, maxWaitTime));
                waitingForPath = true;
            } else {
                if (Vector3.Distance(transform.position, player.transform.position) > 6.0f)
                {
                    path = grid.findPath(transform.position, player.transform.position);
                }
            }
        }
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
	}

    private void findNewRandomPath()
    {
        Node randomNode = grid.getRandomWalkableNode();
        path = grid.findPath(transform.position, randomNode.transform.position);
        waitingForPath = false;
    }

    private Vector3 roundVec(Vector3 vector, float roundTo){
        return new Vector3(
             Mathf.Round(vector.x / roundTo) * roundTo,
             Mathf.Round(vector.y / roundTo) * roundTo,
             Mathf.Round(vector.z / roundTo) * roundTo);
    }

    
}
