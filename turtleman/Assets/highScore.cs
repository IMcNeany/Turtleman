using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class highScore : MonoBehaviour
{
    public Text highScoreText;
    private UI_Manager eggScore;
    public int highScoreInt = 0;
    public SavingModel savingModel;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        //Get json
        LoadGameData();

        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "highscore.json");

        Debug.Log(Application.dataPath);

        Debug.Log(File.Exists(filePath));

        highScoreText.text = "0";

        if (/*eggScore.EggCount > */PlayerPrefs.GetInt("HighScore", 0) >= 0)
        {
           // PlayerPrefs.SetInt("HighScore", eggScore.EggCount);
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            highScoreInt = PlayerPrefs.GetInt("HighScore", 0);

            if (File.Exists(filePath))
            {
     
                Debug.Log("Score In File:" + savingModel.highScoreVal);
                Debug.Log("HighScore = " + highScoreInt);

                //set if higher score
                if(highScoreInt >= savingModel.highScoreVal)
                {
                    savingModel.highScoreVal = highScoreInt;
                    Debug.Log("Saving");

                    highScoreText.text = highScoreInt.ToString();
                    SaveGameData();
                }
                else
                {
                    highScoreText.text = savingModel.highScoreVal.ToString();
                }
            }
            else
            {
                savingModel.highScoreVal = PlayerPrefs.GetInt("HighScore", 0);
                SaveGameData();
            }
        }


    }

    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "highscore.json");

        if (File.Exists(filePath))
        {
            Debug.Log("Got Data");
            string dataAsJson = File.ReadAllText(filePath);
            savingModel = JsonUtility.FromJson<SavingModel>(dataAsJson);
        }
        else
        {
            savingModel = new SavingModel();
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(savingModel);

        string filePath = Path.Combine(Application.streamingAssetsPath, "highscore.json");

        File.WriteAllText(filePath, dataAsJson);

    }

}
