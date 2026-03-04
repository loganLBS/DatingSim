using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour
{
    [System.Serializable]


    public class Background
    {
        public string name; // Name used in Yarn
        public Sprite image; // Background sprite
    }

    public Image backgroundImage; // Fullscreen UI image
    public List<Background> backgrounds; // All backgrounds
    public DialogueRunner dialogueRunner; // Drag your DialogueRunner here

    void Awake()
    {
        if (dialogueRunner == null)
        {
            Debug.LogError("BackgroundController needs a DialogueRunner assigned!");
            return;
        }

        // Register the command handler
        dialogueRunner.AddCommandHandler<string>("SetBackground", SetBackground);
    }

    public void SetBackground(string bgName)
    {
        if (bgName.ToLower() == "hide")
        {
            backgroundImage.gameObject.SetActive(false);
            return;
        }

        foreach (var bg in backgrounds)
        {
            if (bg.name == bgName)
            {
                backgroundImage.sprite = bg.image;
                backgroundImage.gameObject.SetActive(true);
                return;
            }
        }

        Debug.LogWarning("Unknown background: " + bgName);
        backgroundImage.gameObject.SetActive(false);
    }
}