using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;

public class Persona5MenuController : MonoBehaviour
{
    [Header("Cursor Settings")]
    public RectTransform cursorWhite;
    public RectTransform cursorBlack;
    public RectTransform[] menuItems;

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
            }
            else if (navigateValue.y < -0.5f) // Down
            {
                currentIndex++;
                if (currentIndex >= menuItems.Length) currentIndex = 0;
                UpdateCursorPosition();
            }
        }
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        SelectCurrentItem();
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
                Debug.Log("Start Game");
                break;
            case 1:
                Debug.Log("Load Game");
                break;
            case 2:
                Debug.Log("Quit");
                break;
        }
    }
}