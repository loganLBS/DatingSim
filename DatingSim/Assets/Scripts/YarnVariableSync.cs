using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnVariableSync : MonoBehaviour
{
    public DialogueRunner dialogueRunner; // Assign in Inspector

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If no DialogueRunner is assigned, try to find one in the scene
        if (dialogueRunner == null)
        {
            dialogueRunner = FindFirstObjectByType<DialogueRunner>(); // Updated line
            if (dialogueRunner == null)
            {
                UnityEngine.Debug.LogWarning("No DialogueRunner found in scene. Cannot sync variable.");
                return;
            }
        }

        // Sync Yarn variable from persistent data
        if (PersistentData.Instance != null && !string.IsNullOrEmpty(PersistentData.Instance.playerName))
        {
            dialogueRunner.VariableStorage.SetValue("$playerName", PersistentData.Instance.playerName);
            UnityEngine.Debug.Log($"Yarn variable $playerName synced to: {PersistentData.Instance.playerName}");
        }
    }
}