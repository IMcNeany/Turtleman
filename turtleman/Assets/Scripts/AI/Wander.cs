using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    private Grid grid;
    private List<Node> path;
    private int pathIndex = 0;

	// Use this for initialization
	void Start () {
        grid = GameObject.FindGameObjectWithTag("WaypointGrid").GetComponent<Grid>();
        path = grid.findPath(transform.position, new Vector3(30, 0, 20));
	}
	
	// Update is called once per frame
	void Update () {
        if(path != null){
            transform.position = Vector3.MoveTowards(transform.position, path[pathIndex].transform.position, 5.0f * Time.deltaTime);

            if(roundVec(transform.position, 1.0f) == roundVec(path[pathIndex].transform.position, 1.0f)){
                pathIndex++;

                if(pathIndex >= path.Count)
                {
                    path = null;
                    pathIndex = 0;
                }
            }
        }
	}

    private Vector3 roundVec(Vector3 vector, float roundTo){
        return new Vector3(
             Mathf.Round(vector.x / roundTo) * roundTo,
             Mathf.Round(vector.y / roundTo) * roundTo,
             Mathf.Round(vector.z / roundTo) * roundTo);
    }
}
