using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM : MonoBehaviour
{
    GameData saveData = new GameData();

    public static bool newHighScore;
    public static int availableScore;
    public static string topDuckName;
    public static float topHeight;


    private void Start()
    {
        RunLoad();
    }

    private void Update()
    {
        if (newHighScore)
        {
            NewHighScore();
            RunSave();
        }
    }

    public void RunSave()
    {
        SaveLoad.instance.SaveGame(saveData);
    }

    public void RunLoad()
    {
        saveData = SaveLoad.instance.LoadGame();
        displayScore();
    }

    public void NewHighScore()
    {
        Debug.Log("saved");
        saveData.HighScoreFinalise();
        newHighScore = false;
    }

    public void displayScore()
    {
        availableScore = saveData.score;
        topHeight = saveData.maxHeight;
        topDuckName = saveData.highScoreName;
    }
}
