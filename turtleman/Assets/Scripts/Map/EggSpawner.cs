using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject egg;
    public int egg_max = 10;
    public float cool_down = 15.0f;
    public GameObject[] basket;
    private int egg_count = 0;
    private int egg_index = 0;
    private GameObject[] maze;
    private int maze_index = 0;

    public void Init(int size)
    {
        basket = new GameObject[egg_max];
        maze = new GameObject[size -1];
    }

    private void Update()
    {
        for (int i = 0; i < egg_max; i++)
        {
            if (!basket[i])
            {
                AddNewEgg(i);
            }
        }
    }


    private void AddNewEgg(int index)
    {
        int tile = Random.Range(5, maze.Length - 5);
        float spawn_timer = Random.Range(30.0f, 60.0f);
        Vector3 pos = new Vector3(maze[tile].transform.position.x, maze[tile].transform.position.y + 0.5f, maze[tile].transform.position.z);

        basket[index] = Instantiate(egg, pos, Quaternion.identity);
        basket[index].GetComponent<EggBehaviour>().SetTimeToHatch(spawn_timer);
    }

    public void CopyOfMaze(GameObject instan)
    {
        maze[maze_index] = instan;
        maze_index++;
    }

    public void AddEggAtStart(GameObject instan, int row, int index)
    {
        if ((index >= (row * 4)) &&
            Random.Range(0, 9) == 0 && egg_count < egg_max &&
            !basket[egg_index])

        {
            Vector3 pos = new Vector3(instan.transform.position.x, instan.transform.position.y + 0.5f, instan.transform.position.z);
            basket[egg_index] = 
                Instantiate(egg, pos, Quaternion.identity);

            float spawn_timer = Random.Range(30.0f, 60.0f);
            basket[egg_index].GetComponent<EggBehaviour>().SetTimeToHatch(spawn_timer);

            egg_count++;
            egg_index++;
        }
    }

    public void ClearInit()
    {
        egg_count = 0;
        egg_index = 0;
        maze_index = 0;
    }
}
