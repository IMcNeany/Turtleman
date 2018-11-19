using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public class Node
	{
		int gCost;
		int hCost;
		float x, y;
		float gridX, gridY;

		Node parent;

		int calculateFCost() { return gCost + hCost; }
	}

	private Node[] nodes;

	// Use this for initialization
	void Start () {
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
