using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public int gCost;
	public int hCost;
	public int gridX, gridY;
	public Node parent;
	public bool walkable;
	public int calculateFCost() { return gCost + hCost; }
}
