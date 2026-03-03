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

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        dialogueRunner.VariableStorage.SetValue("$playerName", playerName);

        namePanel.SetActive(false);

    }
}