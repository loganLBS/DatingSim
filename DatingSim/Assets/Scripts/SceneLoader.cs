using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.ComponentModel;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private CanvasGroup fadeCanvas; // Optional fade overlay
    [SerializeField] private float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string Ville)
    {
        StartCoroutine(LoadSceneRoutine(Ville));
    }

    private IEnumerator LoadSceneRoutine(string Ville)
    {
        // Fade out
        if (fadeCanvas != null)
        {
            yield return Fade(1);
        }

        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(Ville);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
            yield return null;

        // small delay if desired
        yield return new WaitForSeconds(0.2f);

        operation.allowSceneActivation = true;

        while (!operation.isDone)
            yield return null;

        // Fade back in
        if (fadeCanvas != null)
        {
            yield return Fade(0);
        }
    }

    private IEnumerator Fade(float target)
    {
        float start = fadeCanvas.alpha;
        float time = 0f;

        // If we're fading OUT (to black), block input immediately
        if (target == 1f)
            fadeCanvas.blocksRaycasts = true;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            fadeCanvas.alpha = Mathf.SmoothStep(start, target, t);
            yield return null;
        }

        fadeCanvas.alpha = target;

        // If we're fading IN (back to visible scene), allow input again
        if (target == 0f)
            fadeCanvas.blocksRaycasts = false;
    }
}
