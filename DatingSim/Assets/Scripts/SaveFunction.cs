using UnityEditor.Overlays;
using System.IO;
using UnityEngine;
using Yarn.Unity;

public static class SaveFunction
{
    private static string savePath => Application.persistentDataPath + "/save.json";

    [YarnCommand("Save")]
    public static void Save(SaveInfo Dag1)
    {
        SaveInfo data = new SaveInfo
        {
            //seed = generator.seed,
            //playerPosition = player.transform.position,

            Day = Dag1.Day,
            cassieTrust = Dag1.cassieTrust,
            bebeTrust = Dag1.bebeTrust,
            nancyTrust = Dag1.nancyTrust,
            emikoTrust = Dag1.emikoTrust,
            takikoTrust = Dag1.takikoTrust,
            sashaTrust =  Dag1.sashaTrust,
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
