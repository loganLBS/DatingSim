using UnityEngine;
using TMPro;
using Yarn.Unity;

public class NameUIController : MonoBehaviour
{
    public GameObject namePanel;
    public TMP_InputField nameInputField;
    public DialogueRunner dialogueRunner;

    private System.Action onComplete;

    void Start()
    {
        namePanel.SetActive(false);
    }

    [YarnCommand("ShowNameInput")]
    public void ShowNameInput()
    {
        namePanel.SetActive(true);
        nameInputField.text = "";
        nameInputField.ActivateInputField();
    }

    public void ConfirmName()
    {
        string playerName = nameInputField.text;
        if (string.IsNullOrEmpty(playerName)) playerName = "Player";

        // Save to Yarn (for use in current scene)
        dialogueRunner.VariableStorage.SetValue("$playerName", playerName);

        // Save to persistent data (for cross‑scene use)
        PersistentData.Instance.SetPlayerName(playerName);

        namePanel.SetActive(false);
    }
}