using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float maxWaitTime = 5.0f;
    public float baseSpeed = 5.0f;
    public float groundOffset = 0.15f;
    public float attackSpeed = 2.0f;

    private float speed = 5.0f;
    public float acquisitionRadius = 5.0f;
    public List<Node> path;
    private int pathIndex = 0;
    private bool waitingForPath = false;
    private bool closeRange = false;
    private GameObject player;
    private PlayerController pcontroller;
    private Grid grid;
    private Animator anim;
    private Rigidbody rb;

    public AudioSource audio;
    public List<AudioClip> clips;

    private float startTime;
    private bool timerStarted = false;
    private bool play_once = true;

    public void setClose(bool b) {
        if (b) timerStarted = false;
        closeRange = b;
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
        pcontroller = GameObject.FindGameObjectWithTag
            ("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (closeRange)
        {
            anim.SetBool("moving", false);
            chomp();

            if (!timerStarted) {
                startTime = Time.time;
                timerStarted = true;
            }
        } else if(path != null && path.Count > 0){
            anim.SetBool("attacking", false);
            Vector3 target = path[pathIndex].transform.position;
            target.y = groundOffset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
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
            anim.SetBool("attacking", false);
            anim.SetBool("moving", false);
            if(player == null){
                Invoke("findNewRandomPath", Random.Range(1.0f, maxWaitTime));
                waitingForPath = true;
                play_once = true;
            }
            else {
                if (Vector3.Distance(transform.position, player.transform.position) > 6.0f)
                {
                    if (play_once)
                    {
                        int rand = Random.Range(0, 2);
                        audio.clip = clips[rand];
                        audio.Play();
                        play_once = false;
                    }
                    path = grid.findPath(transform.position, player.transform.position);
                }
            }
        }
        rb.velocity = Vector3.zero;
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

    private void chomp() {

        int playerCurrentHealth = pcontroller.getHealth();
        if (Time.time - startTime >= attackSpeed)
        {
            anim.SetBool("attacking", true);
            startTime = Time.time;
            transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            Debug.Log("C H O M P");
            audio.clip = clips[3];
            audio.Play();
            pcontroller.setHealth(playerCurrentHealth -= 1);
        }
    }

    
}
