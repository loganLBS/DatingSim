using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections.Generic;

public class CharacterMoodController : MonoBehaviour
{
    [System.Serializable]
    public class MoodSprites
    {
        public Sprite happy;
        public Sprite neutral;
        public Sprite angry;
        public Sprite unknown;
    }

    [System.Serializable]
    public class Character
    {
        public string name;       // Must match Yarn character name
        public Image image;       // The UI Image that shows this character
        public MoodSprites moods; // Their 3 sprites
    }

    public DialogueRunner dialogueRunner;
    public List<Character> characters;

    void Start()
    {
        // Register the command handler in code
        dialogueRunner.AddCommandHandler<string>("SetMood", SetMood);
    }

    public void SetMood(string characterAndMood)
    {
        // Expected format: "Emiko happy"
        string[] split = characterAndMood.Split(' ');
        if (split.Length != 2) return;

        string characterName = split[0];
        string mood = split[1].ToLower();

        foreach (var c in characters)
        {
            if (c.name == characterName)
            {
                switch (mood)
                {
                    case "happy":
                        c.image.sprite = c.moods.happy;
                        c.image.gameObject.SetActive(true);
                        break;
                    case "neutral":
                        c.image.sprite = c.moods.neutral;
                        c.image.gameObject.SetActive(true);
                        break;
                    case "angry":
                        c.image.sprite = c.moods.angry;
                        c.image.gameObject.SetActive(true);
                        break;
                    case "unknown":
                        c.image.sprite = c.moods.unknown;
                        c.image.gameObject.SetActive(true);
                        break;
                    default:
                        c.image.gameObject.SetActive(false);
                        break;
                }
                return;
            }
        }

        Debug.LogWarning("Unknown character in SetMood: " + characterName);
    }
}