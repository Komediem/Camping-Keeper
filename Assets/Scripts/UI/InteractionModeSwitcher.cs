using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionModeSwitcher : MonoBehaviour
{
    public PlayerInput input;

    public GameObject virtualCursor;

    private void OnEnable()
    {
            Cursor.visible = true;
            virtualCursor.SetActive(true);

            input.SwitchCurrentActionMap("UI");
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        virtualCursor.SetActive(false);

        input.SwitchCurrentActionMap("Player");
    }
}
