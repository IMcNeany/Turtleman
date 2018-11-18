using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    public int row = 12;
    public int col = 12;
    public int scale = 0;
    public GameObject[] tile;
    private GameObject[] maze;
    private char[] maze_data;
    private GameObject instan;
    private GameObject maze_holder;

    private void Start()
    {
        maze = new GameObject[row * col];
        maze_data = new char[row * col];
        maze_holder = GameObject.Find("MazeHolder");

        LoadFromFile();
        CreateMaze();
    }

    private void LoadFromFile()
    {
        int rand = Random.Range(0, 4);
        string path = "Assets/LevelsFiles/LevelData" + rand + ".txt";
        Debug.Log("Loading Level: " + rand);
        StreamReader sr = new StreamReader(path);
        int count = 0;

        for (int i = 0; i < col; i++)
        {
            string line;
            line = sr.ReadLine();
            char[] c = new char[line.Length];

            for (int j = 0; j < line.Length; j++)
            {
                c[j] = line[j];
                maze_data[count] = c[j];
                count++;
            }
        }
        sr.Close();
    }

    private void CreateMaze()
    {
        for(int i = 0; i < maze_data.Length; i++)
        {
            switch(maze_data[i])
            {
                case '0':
                    maze[i] = tile[0];
                    break;
                case '1':
                    maze[i] = tile[1];
                    break;
                case '2':
                    maze[i] = tile[2];
                    break;
            }            
        }

        int count = 0;
        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                instan = Instantiate(maze[count], (new Vector3(j * scale, 0.1f, i * scale)), Quaternion.identity);
                if(maze[count] == tile[1])
                {
                    instan.transform.position = new Vector3(instan.transform.position.x, 2.5f, instan.transform.position.z);
                }
                instan.name = "Tile: " + i + j;
                instan.transform.parent = maze_holder.transform;
                count++;
            }
        }
    }
}
