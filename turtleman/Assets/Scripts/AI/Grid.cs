using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public float nodeDiameter = 5.0f;
    public int rows;
    public int cols;
    private int width;
    private int height;

    private Node[] nodes;
	// Use this for initialization
	void Start () {
        width = (int)(rows * nodeDiameter);
        height = (int)(cols * nodeDiameter);
        generateNodes();
	}

    public List<Node> findPath(Vector3 position, Vector3 target) {
        Node start = getNodeFromPosition(position);
        Node end = getNodeFromPosition(target);

        List<Node> openSet = new List<Node>();
        List<Node> closedSet = new List<Node>();

        openSet.Add(start);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].calculateFCost() < currentNode.calculateFCost() //If it has a lower fCost
                || openSet[i].calculateFCost() == currentNode.calculateFCost() // Or if the fCost is the same but the hCost is lower
                && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == end) {
                return tracePath(start, end);    //End reached trace path back
            }

            foreach (Node neighbour in getNeighbours(currentNode)) {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                    continue;

                //Calculate the new lowest costs for the neighbour nodes
                int costToNeighbour = currentNode.gCost + getDistance(currentNode, neighbour);
                if (costToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = costToNeighbour;
                    neighbour.hCost = getDistance(neighbour, end);
                    neighbour.parent = currentNode;    //Set parent node

                    openSet.Add(neighbour);
                }
            }

        }

        return null;
    }

    public Node getRandomWalkableNode(){
        Node selected = null;

        do{
            int index = Random.Range(0, nodes.Length - 1);
            selected = nodes[index];
        }while(!selected.walkable);
        
        return selected;
    }
	
	private void generateNodes(){
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		nodes = new Node[waypoints.Length];
		
		int index = 0;
		foreach(GameObject go in waypoints){
			Node node = go.GetComponent<Node>();
			node.gridX = (int)(node.transform.position.x / nodeDiameter);
			node.gridY = (int)(node.transform.position.z / nodeDiameter);

			nodes[index++] = node;
		}
	}

	private Node getNodeFromPosition(Vector3 position){
        int gridX = (int)(position.x / nodeDiameter);
        int gridY = (int)(position.z / nodeDiameter);

        int index = gridX + (gridY * rows);
        Node node = null;

        if (index < nodes.Length) {
            node = nodes[index];
        }
        
        return node;
    }

    private List<Node> getNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if ((Mathf.Abs(x) == Mathf.Abs(y)))
                {
                    continue;
                }

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < rows && checkY >= 0 && checkY < cols)
                {
                    neighbours.Add(nodes[checkX + checkY * rows]);
                }
            }
        }

        return neighbours;
    }

    private int getDistance(Node a, Node b)
    {
        int distX = Mathf.Abs(a.gridX - b.gridX);
        int distY = Mathf.Abs(a.gridY - b.gridY);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        else
        {
            return 14 * distX + 10 * (distY - distX);
        }
    }

    private List<Node> tracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node currentNode = end;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }
}
