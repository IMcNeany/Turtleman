using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]               // 1

public class GameController : MonoBehaviour
{
    private MazeConstructor generator;

    void Start()
    {
        generator = GetComponent<MazeConstructor>();      // 2
        generator.GenerateNewMaze(13, 15);
    }
}