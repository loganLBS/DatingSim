using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PhoneCallManager : MonoBehaviour
{
    [System.Serializable]
    public struct Caller
    {
        public string callerName;
        public Sprite portrait;
    }

    public UnityEngine.UI.Image phoneImage;
    public UnityEngine.UI.Image callerPortraitImage;
    public Caller[] callers;
    public float callDuration = 5f;          // How long each caller shows
    public bool autoCycle = true;             // Enable automatic cycling
    public int startIndex = 0;                 // Which caller to start with

    private Animator phoneAnimator;
    private PhoneRinger simpleRinger;
    private int currentIndex;

    void Start()
    {
        phoneAnimator = phoneImage.GetComponent<Animator>();
        simpleRinger = phoneImage.GetComponent<PhoneRinger>();

        if (callers.Length == 0)
        {
            UnityEngine.Debug.LogError("No callers assigned!");
            return;
        }

        // Start the call with the first caller and begin cycling
        currentIndex = startIndex;
        StartCoroutine(AutoCallCycle());
    }

    IEnumerator AutoCallCycle()
    {
        while (autoCycle)
        {
            // Show the current caller
            ShowCaller(currentIndex);

            // Wait for the call duration
            yield return new WaitForSeconds(callDuration);

            // Move to the next caller (loop back to 0 at the end)
            currentIndex = (currentIndex + 1) % callers.Length;
        }
    }

    void ShowCaller(int index)
    {
        if (index < 0 || index >= callers.Length) return;

        UnityEngine.Debug.Log($"Showing caller {index}: {callers[index].callerName}");

        if (callers[index].portrait == null)
        {
            UnityEngine.Debug.LogWarning($"Portrait for caller {index} is null!");
        }

        callerPortraitImage.sprite = callers[index].portrait;

        // Trigger ring animation (optional – you might want this only once, not per switch)
        if (phoneAnimator != null)
            phoneAnimator.SetBool("IsRinging", true);
        else if (simpleRinger != null)
            simpleRinger.StartRinging();
    }

    public void EndCall()
    {
        // Stop cycling and hide phone
        autoCycle = false;
        StopAllCoroutines();

        if (phoneAnimator != null)
            phoneAnimator.SetBool("IsRinging", false);
        else if (simpleRinger != null)
            simpleRinger.StopRinging();

        // Optionally clear portrait
        callerPortraitImage.sprite = null;
    }
}