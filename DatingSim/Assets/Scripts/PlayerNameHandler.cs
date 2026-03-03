using UnityEngine;
using TMPro;
using Yarn.Unity;

public class PlayerNameHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject confirmButton;
    public DialogueRunner dialogueRunner;

    public void ConfirmName()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        dialogueRunner.VariableStorage.SetValue("$playerName", playerName);

        // Hide UI
        nameInputField.gameObject.SetActive(false);
        confirmButton.SetActive(false);

        // OR (cleaner option)
        // namePanel.SetActive(false);

    }
}