using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM : MonoBehaviour
{
    GameData saveData = new GameData();


    public void RunSave()
    {
        SaveLoad.instance.SaveGame(saveData);
    }
    public void RunLoad()
    {
        saveData = SaveLoad.instance.LoadGame();
    }

    public void ResetScore()
    {
        saveData.ResetData();
    }

}
