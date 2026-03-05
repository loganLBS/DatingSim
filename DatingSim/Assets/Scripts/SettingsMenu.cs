using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    public Button closeButton;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        // Start hidden
        gameObject.SetActive(false);

        // Set up listeners (if you have UI buttons)
        
        if (closeButton != null)
            closeButton.onClick.AddListener(CloseSettings);
    }

    public void OpenSettings()
    {
        // Kill any tweens currently running on these components
        rectTransform.DOKill();
        canvasGroup.DOKill();

        // Ensure the panel is active
        gameObject.SetActive(true);

        // Reset scale and alpha before animating
        rectTransform.localScale = Vector3.zero;
        canvasGroup.alpha = 0f;

        // Animate: pop up and fade in
        rectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        canvasGroup.DOFade(1f, 0.2f);

        // Make it interactable
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    void CloseSettings()
    {
        // Kill any tweens
        rectTransform.DOKill();
        canvasGroup.DOKill();

        // Disable interaction immediately
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Animate: scale down and fade out
        Sequence closeSequence = DOTween.Sequence();
        closeSequence.Join(rectTransform.DOScale(0f, 0.2f).SetEase(Ease.InBack));
        closeSequence.Join(canvasGroup.DOFade(0f, 0.2f));
        closeSequence.OnComplete(() => gameObject.SetActive(false));
    }
}