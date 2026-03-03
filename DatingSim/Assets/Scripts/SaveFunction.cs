using UnityEditor.Overlays;
using System.IO;
using UnityEngine;

public static class SaveFunction
{
    private static string savePath => Application.persistentDataPath + "/save.json";

    public static void Save(Dag1)
    {
        SaveInfo data = new SaveInfo
        {
            //seed = generator.seed,
            //playerPosition = player.transform.position,

            Day = //VS.Day
            cassieTrust = //VS.Cassie
            bebeTrust = //VS.Bebe
            nancyTrust = //VS.Nancy
            emikoTrust = //VS.Emiko
            takikoTrust = //VS.Takiko
            sashaTrust =  //VS.Sasha
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved");
    }

    public static SaveInfo Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("No save file found");
            return null;
        }

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<SaveInfo>(json);
    }
}
