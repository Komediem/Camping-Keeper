using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] 
    private PlayerInput playerInput;

    [SerializeField] 
    private RectTransform cursorTransform;

    [SerializeField]
    private RectTransform canvasRectTransform;
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private float cursorSpeed = 1000f;
    [SerializeField]
    private float padding = 35f;

    private Mouse virtualMouse;
    private Mouse currentMouse;
    private Camera mainCamera;

    private bool previousMouseState;

    private string previousControlSceme = "";
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";

    private void Update()
    {
        if (previousControlSceme != playerInput.currentControlScheme)
        {
            OnControlsChanged(playerInput);
        }
        previousControlSceme = playerInput.currentControlScheme;
    }

    private void OnEnable()
   {
        mainCamera = Camera.main;
        currentMouse = Mouse.current;

        InputDevice virtualMouseInputDevice = InputSystem.GetDevice("VirtualMouse");

        if(virtualMouse == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }

        //Pair the device to the user to use the PlayerInput component with the Event System & the Virtual Mouse
        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;

        playerInput.onControlsChanged += OnControlsChanged;
    }

    private void OnDisable()
    {
        if(virtualMouse != null && virtualMouse.added) InputSystem.RemoveDevice(virtualMouse);

        InputSystem.onAfterUpdate -= UpdateMotion;
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    private void UpdateMotion()
    {
        if (virtualMouse != null || Gamepad.current == null)
        { 
            return; 
        }

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = virtualMouse.position.ReadValue();
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, padding, Screen.width - padding);
        newPosition.y = Mathf.Clamp(newPosition.y, padding, Screen.height - padding);

        InputState.Change(virtualMouse.position, newPosition);
        InputState.Change(virtualMouse.delta, deltaValue);

        bool aButtonIsPressed = Gamepad.current.aButton.IsPressed();
        if (previousMouseState != aButtonIsPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }

        AnchorCursor(newPosition);
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, 
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchoredPosition);

        cursorTransform.anchoredPosition = anchoredPosition;
    }

    private void OnControlsChanged(PlayerInput input)
    {
        if (playerInput.currentControlScheme == mouseScheme && previousControlSceme != mouseScheme)
        {
             cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());

            previousControlSceme = mouseScheme;
        }
        else if (playerInput.currentControlScheme == gamepadScheme && previousControlSceme != gamepadScheme)
        {
            cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;

            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
            previousControlSceme = gamepadScheme;
        }
    }
}
