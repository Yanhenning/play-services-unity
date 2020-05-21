using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    public static GameSave SaveGame(GameSave currentData, string fileName)
    {
        GameSave gameSave = new GameSave();
        gameSave.score = currentData.score;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetSavePath(fileName));
        bf.Serialize(file, gameSave);
        file.Close();

        return gameSave;
    }

    public static GameSave LoadGame(string fileName)
    {
        GameSave save = null;
        if (FileSaveExists(fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(GetSavePath(fileName), FileMode.Open);
            save = (GameSave)bf.Deserialize(file);
            file.Close();
        }
        return save;
    }

    public static bool FileSaveExists(string fileName) => File.Exists(GetSavePath(fileName));

    private static string GetSavePath(string fileName) => Application.persistentDataPath + "/" + fileName + ".save";
}
