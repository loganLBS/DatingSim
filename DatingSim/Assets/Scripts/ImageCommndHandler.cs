using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ImageCommndHandler : MonoBehaviour
{
    public Image displayImage;      // UI Image component
    public Sprite[] sprites;        // Assign sprites in inspector
    public string[] spriteNames;    // Matching names

    [YarnCommand("showImage")]
    public void ShowImage(string imageName)
    {
        for (int i = 0; i < spriteNames.Length; i++)
        {
            if (spriteNames[i] == imageName)
            {
                displayImage.sprite = sprites[i];
                displayImage.enabled = true;
                return;
            }
        }

        Debug.LogWarning("Image not found: " + imageName);
    }

    [YarnCommand("hideImage")]
    public void HideImage()
    {
        displayImage.enabled = false;
    }
}