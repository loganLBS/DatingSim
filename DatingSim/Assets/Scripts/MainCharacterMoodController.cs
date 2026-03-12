using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using static System.Net.Mime.MediaTypeNames;

public class MainCharacterMoodController : MonoBehaviour
{
    [System.Serializable]
    public struct MoodSprites
    {
        public Sprite happy;
        public Sprite neutral;
        public Sprite angry;
        public Sprite neutral2;
        public Sprite flushed;
    }

    [Header("References")]
    public UnityEngine.UI.Image characterImage;           // The UI Image that shows the character
    public MoodSprites moods;               // Sprites for each mood

    [Header("Yarn")]
    public DialogueRunner dialogueRunner;   // Assign in Inspector

    void Start()
    {
        if (dialogueRunner == null)
        {
            UnityEngine.Debug.LogError("MainCharacterMoodController: DialogueRunner is not assigned!");
            return;
        }

        // Register the Yarn command "SetMainMood" that takes one string argument (the mood)
        dialogueRunner.AddCommandHandler<string>("SetMainMood", SetMainMood);
    }

    // Called from Yarn like: <<SetMainMood happy>>
    public void SetMainMood(string mood)
    {
        // Convert to lowercase for case-insensitive matching
        string moodLower = mood.ToLower();

        // Determine which sprite to use
        Sprite targetSprite = null;
        switch (moodLower)
        {
            case "happy":
                targetSprite = moods.happy;
                break;
            case "neutral":
                targetSprite = moods.neutral;
                break;
            case "angry":
                targetSprite = moods.angry;
                break;
            case "neutral2":
                targetSprite = moods.neutral2;
                break;
            case "flushed":
                targetSprite = moods.flushed;
                break;
            default:
                UnityEngine.Debug.LogWarning($"Unknown mood '{mood}'. Hiding character image.");
                characterImage.gameObject.SetActive(false);
                return;
        }

        // Apply the sprite and make sure the image is visible
        if (targetSprite != null)
        {
            characterImage.sprite = targetSprite;
            characterImage.gameObject.SetActive(true);
        }
        else
        {
            UnityEngine.Debug.LogWarning($"Sprite for mood '{mood}' is missing. Hiding character image.");
            characterImage.gameObject.SetActive(false);
        }
    }
}