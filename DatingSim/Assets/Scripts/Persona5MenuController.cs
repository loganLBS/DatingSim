using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System;

public class Persona5MenuController : MonoBehaviour
{
    [Header("Cursor Settings")]
    public RectTransform cursorWhite;
    public RectTransform cursorBlack;
    public RectTransform[] menuItems;
    public SettingsMenu settingsMenu;   // Drag the SettingsPanel here
    public AudioSource audioSource;      // Drag the AudioSource component here
    public AudioClip moveSound;          // Sound for cursor movement
    public AudioClip selectSound;        // Sound for confirming a selection

    [Header("Input")]
    public MenuControls inputActions;

    private int currentIndex = 0;
    private Vector3 cursorOffset; // Stores the initial offset from the first menu item

    private void Awake()
    {
        inputActions = new MenuControls();
    }

    private void OnEnable()
    {
        inputActions.Menu.Enable();
        inputActions.Menu.Submit.performed += OnSubmit;
    }

    private void OnDisable()
    {
        inputActions.Menu.Submit.performed -= OnSubmit;
        inputActions.Menu.Disable();
    }

    private void Start()
    {
        if (menuItems.Length > 0)
        {
            cursorOffset = cursorWhite.position - menuItems[0].position;
        }
        UpdateCursorPosition();
    }

    private void Update()
    {
        // Check if the Navigate action was pressed this frame
        if (inputActions.Menu.Navigate.WasPressedThisFrame())
        {
            Vector2 navigateValue = inputActions.Menu.Navigate.ReadValue<Vector2>();

            if (navigateValue.y > 0.5f) // Up
            {
                currentIndex--;
                if (currentIndex < 0) currentIndex = menuItems.Length - 1;
                UpdateCursorPosition();
                PlayMoveSound();
            }
            else if (navigateValue.y < -0.5f) // Down
            {
                currentIndex++;
                if (currentIndex >= menuItems.Length) currentIndex = 0;
                UpdateCursorPosition();
                PlayMoveSound();
            }
        }
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        SelectCurrentItem();
        PlaySelectSound();
    }
    private void PlaySelectSound()
    {
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }
    }
    private void PlayMoveSound()
    {
        if (audioSource != null && moveSound != null)
        {
            audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f); // slight variation
            audioSource.PlayOneShot(moveSound);
        }
    }
    void UpdateCursorPosition()
    {
        Vector3 newPos = menuItems[currentIndex].position + cursorOffset;
        cursorWhite.position = newPos;
        cursorBlack.position = newPos;
    }

    void SelectCurrentItem()
    {
        switch (currentIndex)
        {
            case 0:
                UnityEngine.Debug.Log("Start Game");
                SceneLoader.Instance.LoadScene("Ville");
                break;

            case 1:
                UnityEngine.Debug.Log("Settings");
                if (settingsMenu == null) UnityEngine.Debug.LogError("settingsMenu is null!");
                else settingsMenu.OpenSettings();
                break;

            case 2:
                UnityEngine.Debug.Log("Load");
                SaveFunction.Load();
                break;
            case 3:
                UnityEngine.Debug.Log("Quit");
                UnityEngine.Application.Quit();
                break;
        }
    }
}