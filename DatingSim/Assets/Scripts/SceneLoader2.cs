using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Yarn.Unity; // Add this namespace

public class SceneLoader2 : MonoBehaviour
{
    public static SceneLoader2 Instance;
    public DTSMiddleman DTS;

    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeDuration = 0.5f;

    // Reference to your Yarn Dialogue Runner
    [SerializeField] private DialogueRunner dialogueRunner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //else
       // {
            //Destroy(gameObject);
       // }
    }

    private void Start()
    {
        // Register the command with Yarn Spinner
        if (dialogueRunner != null)
        {
            // This makes <<LoadNextScene>> call the LoadNextScene() method
            dialogueRunner.AddCommandHandler("NextDay", NextDay);
            UnityEngine.Debug.Log("Yarn command 'NextDay' registered successfully");
        }
        else
        {
            UnityEngine.Debug.LogError("DialogueRunner reference not set in SceneLoader!");
        }
    }

    public void NextDay()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadSceneRoutine(nextIndex));
            DTS.NextDay();
        }
        else
        {
            UnityEngine.Debug.LogError("No next scene in build settings!");
        }
    }

    private IEnumerator LoadSceneRoutine(int buildIndex)
    {
        // Fade out
        if (fadeCanvas != null)
        {
            yield return Fade(1);
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
            yield return null;

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

    // Optional: Clean up when destroyed
     private void OnDestroy()
    {
        if (dialogueRunner != null)
        {
           // dialogueRunner.RemoveCommandHandler("NextDay");
        }
    }
}