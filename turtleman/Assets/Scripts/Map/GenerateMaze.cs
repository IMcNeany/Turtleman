using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    public int row = 15;
    public int col = 15;
    public int scale = 5;

    public GameObject[] tile;
    public GameObject egg;
    public bool debug = false; //display maze visual
    //public int number_of_starting_eggs = 5;

    private string[] maze_data;
    private string msg = "";
    private int[,] data;
    //private int[] eggs;
    //private int egg_count = 5;
    private float placementThreshold;
    private bool has_set_player = false;
    private GameObject[] maze;
    private GameObject instan;
    private GameObject maze_holder;
    private GameObject player;

    private void MazeDataGenerator()
    {
        placementThreshold = .1f;                               
    }

    private int[,] FromDimensions(int sizeRows, int sizeCols)  
    {
        int[,] maze = new int[sizeRows, sizeCols];
        // stub to fill in
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = 0; i <= rMax; i++)
        {
            for (int j = 0; j <= cMax; j++)
            {
                if (i == 0 || j == 0 || i == rMax || j == cMax)
                {
                    maze[i, j] = 1;
                }
              
                else if (i % 2 == 0 && j % 2 == 0)
                {
                    if (Random.value > placementThreshold)
                    {
                        maze[i, j] = 1;

                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        maze[i + a, j + b] = 1;
                    }
                }
            }
        }
        return maze;
    }

    private void PopulateMaze()
    {
        data = FromDimensions(row, col);
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);    
        int index = 0;
        string temp = "";

        for (int i = rMax; i >= 0; i--)
        {
            for (int j = 0; j <= cMax; j++)
            {
                if (maze[i, j] == 0)
                {
                    msg += "....";
                    temp = "....";
                }
                else
                {
                    msg += "==";
                    temp = "==";
                }
                maze_data[index] = temp;
                index++;
            }
            msg += "\n";
        }
    }

    private void Start()
    {
        maze = new GameObject[row * col];
        maze_data = new string[row * col];
        maze_holder = GameObject.Find("MazeHolder");
        player = GameObject.FindGameObjectWithTag("Player");
        //egg_count = number_of_starting_eggs;
        //eggs = new int[number_of_starting_eggs];

        // default to walls surrounding a single empty cell
        data = new int[,]
        {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };
        
        PopulateMaze();
        //LoadFromFile();
        InstantiateMaze();
    }

    //private void LoadFromFile()
    //{
        //int rand = Random.Range(0, 4);
        //string path = "Assets/LevelsFiles/LevelData" + rand + ".txt";
        //Debug.Log("Loading Level: " + rand);
        //StreamReader sr = new StreamReader(path);
        //int count = 0;

        //for (int i = 0; i < col; i++)
        //{
        //    string line;
        //    line = sr.ReadLine();
        //    char[] c = new char[line.Length];

        //    for (int j = 0; j < line.Length; j++)
        //    {
        //        c[j] = line[j];
        //        maze_data[count] = c[j];
        //        count++;
        //    }
        //}
        //sr.Close();
    //}

    void OnGUI()
    {
        if(debug) // display maze
        {
            GUI.Label(new Rect(20, 20, 500, 500), msg);
        }
    }

    private void InstantiateMaze()
    {
        bool gate = false;
        for(int i = 0; i < maze_data.Length; i++)
        {
            switch(maze_data[i])
            {
                case "....": // wall
                    if(!gate)
                    {
                        maze[i] = tile[2];
                        gate = true;
                    }
                    else
                    {
                        maze[i] = tile[0];
                    }
                    break;
                case "==": // empty tile
                    maze[i] = tile[1];
                    break;
            }            
        }

        int index = 0;
        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                instan = Instantiate(maze[index], (new Vector3(j * scale, 0.1f, i * scale)), Quaternion.identity);
                if(maze[index] == tile[1])
                {
                    instan.transform.position = new Vector3(instan.transform.position.x, 2.5f, instan.transform.position.z);
                }
                if (maze[index] == tile[2])
                {
                    if(!has_set_player) // check to spawn player on first open floor 
                    {
                        player.transform.position = instan.transform.position;
                        has_set_player = true;
                    }
                    //if(index >= row * 5)
                    //{
                    //    if(egg_count > 0)
                    //    {
                    //        Instantiate(egg, instan.transform.position, Quaternion.identity);
                    //        egg_count--;
                    //    }
                    //}
                }
                instan.name = "Tile: " + i + j;
                instan.transform.parent = maze_holder.transform;
                index++;
            }
        }
    }
}
