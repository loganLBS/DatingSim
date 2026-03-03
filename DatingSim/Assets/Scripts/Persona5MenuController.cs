using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; // Required for Input System

public class Persona5MenuController : MonoBehaviour
{
    [Header("Cursor Settings")]
    public RectTransform cursorWhite;
    public RectTransform cursorBlack;
    public RectTransform[] menuItems;

    [Header("Input")]
    public MenuControls inputActions; // Reference to the generated class

    private int currentIndex = 0;

    private void Awake()
    {
        inputActions = new MenuControls();
    }

    private void OnEnable()
    {
        inputActions.Menu.Enable();
        // Subscribe to the Submit action
        inputActions.Menu.Submit.performed += OnSubmit;
    }

    private void OnDisable()
    {
        inputActions.Menu.Submit.performed -= OnSubmit;
        inputActions.Menu.Disable();
    }

    private void Start()
    {
        UpdateCursorPosition();
    }

    private void Update()
    {
        // Read the Navigate value (Vector2)
        Vector2 navigate = inputActions.Menu.Navigate.ReadValue<Vector2>();

        if (navigate.y > 0.5f) // Up
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = menuItems.Length - 1;
            UpdateCursorPosition();
        }
        else if (navigate.y < -0.5f) // Down
        {
            currentIndex++;
            if (currentIndex >= menuItems.Length) currentIndex = 0;
            UpdateCursorPosition();
        }
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        // This is called when the Submit action is performed
        SelectCurrentItem();
    }

    void UpdateCursorPosition()
    {
        Vector3 newPos = menuItems[currentIndex].position;
        cursorWhite.position = newPos;
        cursorBlack.position = newPos;
    }

    void SelectCurrentItem()
    {
        switch (currentIndex)
        {
            case 0:
                Debug.Log("Start Game");
                // Load your game scene
                break;
            case 1:
                Debug.Log("Load Game");
                break;
            case 2:
                Debug.Log("Options");
                break;
            case 3:
                Debug.Log("Quit");
                Application.Quit();
                break;
        }
    }
}