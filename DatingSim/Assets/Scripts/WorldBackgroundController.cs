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
    public Sprite classroom;
    public Sprite reception;

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

            case "classroom":
                spriteRenderer.sprite = corridor;
                break;

            case "reception":
                spriteRenderer.sprite = corridor;
                break;

            default:
                Debug.LogWarning("Unknown background: " + bgName);
                return;
        }

        spriteRenderer.enabled = true;
    }
}