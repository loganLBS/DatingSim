using UnityEngine;
using Yarn.Unity;

public class WorldBackgroundController : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public SpriteRenderer spriteRenderer;

    public Sprite corridor;
    public Sprite library;
    public Sprite cafeteria;
    public Sprite gymnasium;
    public Sprite school;

    void Awake()
    {
        dialogueRunner.AddCommandHandler<string>("bg", ChangeBackground);
    }

    void ChangeBackground(string bgName)
    {
        switch (bgName.ToLower())
        {
            case "corridor":
                spriteRenderer.sprite = corridor;
                break;

            case "library":
                spriteRenderer.sprite = library;
                break;

            case "cafeteria":
                spriteRenderer.sprite = cafeteria;
                break;

            case "gymnasium":
                spriteRenderer.sprite = gymnasium;
                break;

            case "school":
                spriteRenderer.sprite = school;
                break;

            case "hide":
                spriteRenderer.enabled = false;
                return;

            default:
                Debug.LogWarning("Unknown background: " + bgName);
                return;
        }

        spriteRenderer.enabled = true;
    }
}