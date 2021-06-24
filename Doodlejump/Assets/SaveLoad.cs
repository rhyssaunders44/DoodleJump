using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    static public SaveLoad instance;
    [SerializeField] private string filePath;
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/save.data";

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveGame(GameData saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }

    public GameData LoadGame()
    {
        if (File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            GameData saveData = converter.Deserialize(dataStream) as GameData;

            dataStream.Close();
            return saveData;
        }
        else
        {
            return null;
        }
    }
}
