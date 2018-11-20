﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float maxWaitTime = 5.0f;
    public float speed = 5.0f;
    public float acquisitionRadius = 5.0f;
    private Grid grid;
    private List<Node> path;
    private int pathIndex = 0;
    private bool waitingForPath = false;
    private GameObject player;

    public void playerAquired(GameObject player){
        this.player = player;
    }

    public void deAquire(){
        player = null;
    }

	// Use this for initialization
	void Start () {
        grid = GameObject.FindGameObjectWithTag("WaypointGrid").GetComponent<Grid>();
	}
	
	// Update is called once per frame
	void Update () {
        if(path != null){
            transform.position = Vector3.MoveTowards(transform.position, path[pathIndex].transform.position, speed * Time.deltaTime);

            if(roundVec(transform.position, 1.0f) == roundVec(path[pathIndex].transform.position, 1.0f)){
                pathIndex++;

                if(pathIndex >= path.Count)
                {
                    path = null;
                    pathIndex = 0;
                }
            }
        } else if(!waitingForPath){
            if(player == null){
                Invoke("findNewRandomPath", Random.Range(1.0f, maxWaitTime));
                waitingForPath = true;
            } else {
                path = grid.findPath(transform.position, player.transform.position);
            }
        }
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
