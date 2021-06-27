using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public string highScoreName;
    public float maxHeight;

    public void HighScoreFinalise()
    {
        score = UiManager.Score;
        highScoreName = UiManager.playerName;
        maxHeight = UiManager.distanceTravelled;
    }


   

}
