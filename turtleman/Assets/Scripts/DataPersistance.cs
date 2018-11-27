using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public int player_count = 0;
    public float floating_point = 0.0f;
    public bool boolean = false;
    public char character = ' ';
    public string literal_string = "";
    public Vector3 vector_3 = new Vector3(0, 0, 0);
    public Vector2 vector_2 = new Vector2(0, 0);
    public GameObject game_object = null;
    public Material material = null;
    public int score;
    public int health;
    void Awake()
    {
        //make sure only 1 version of this object exsists
        if (GameObject.FindGameObjectsWithTag("GameController").Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetInt(int val) //Setters
    {
        player_count = val;
    }

    public void SetFloat(float val)
    {
        floating_point = val;
    }

    public void SetBool(bool val)
    {
        boolean = val;
    }

    public void SetCharacter(char val)
    {
        character = val;
    }

    public void SetLiteralString(string val)
    {
        literal_string = val;
    }

    public void SetVector3(Vector3 val)
    {
        vector_3 = val;
    }

    public void SetVector2(Vector2 val)
    {
        vector_2 = val;
    }

    public void SetGameObject(GameObject val)
    {
        game_object = val;
    }

    public void SetMaterial(Material val)
    {
        material = val;
    }

    public void SetPlayerCount(int val)
    {
        player_count = val;
    }

    public int GetInt() //Getters
    {
        return player_count;
    }

    public float GetFloat()
    {
        return floating_point;
    }

    public bool GetBool()
    {
        return boolean;
    }

    public char GetCharacter()
    {
        return character;
    }

    public string GetLiteralString()
    {
        return literal_string;
    }

    public Vector3 GetVector3()
    {
        return vector_3;
    }

    public Vector2 GetVector2()
    {
        return vector_2;
    }

    public GameObject GetGameObject()
    {
        return game_object;
    }

    public Material GetMaterial()
    {
        return material;
    }

    public void FlushData() //Reset held data
    {
        score = 0;
        health = 0;
    }

    public void setPlayerScore(int s)
    {
        score = s;
    }

    public int getPlayerScore()
    {
        return score;
    }

    public void setPlayerHealth(int h)
    {
        health = h;
    }

    int getPlayerHealth()
    {
        return health;
    }
}