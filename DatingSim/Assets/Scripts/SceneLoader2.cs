using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

public class SceneLoader2 : MonoBehaviour
{
    public static SceneLoader2 Instance;

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

    // --- Load the next scene in build order ---
    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadSceneRoutine(nextIndex));
        }
        else
        {
            UnityEngine.Debug.LogError("No next scene in build settings!");
        }
    }

    // --- Coroutine that handles the fade and scene loading ---
    private IEnumerator LoadSceneRoutine(int buildIndex)
    {
        // Fade out
        if (fadeCanvas != null)
        {
            yield return Fade(1);
        }

        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
            yield return null;

        // Optional small delay
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

        if (target == 0f)
            fadeCanvas.blocksRaycasts = false;
    }
}