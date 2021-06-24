using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public static int score = 0;
    public static string highScoreName;
    public static float maxHeight;

    public static void HighScoreFinalise()
    {
        score = UiManager.Score;
        highScoreName = UiManager.playerName;
        maxHeight = UiManager.distanceTravelled;
    }



    public void ResetData()
    {
        score = 0;
        highScoreName = null;
        maxHeight = 0;
    }
}
