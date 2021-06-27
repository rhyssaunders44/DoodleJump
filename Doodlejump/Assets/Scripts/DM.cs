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

    //loads binary data on load
    private void Start()
    {
        RunLoad();
    }

    //if there is a new highscore save the values.
    private void Update()
    {
        if (newHighScore)
        {
            NewHighScore();
            RunSave();
        }
    }

    // save data instance
    public void RunSave()
    {
        SaveLoad.instance.SaveGame(saveData);
    }

    //load and update scores
    public void RunLoad()
    {
        saveData = SaveLoad.instance.LoadGame();
        displayScore();
    }

    //set high scores and stop updating
    public void NewHighScore()
    {
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
