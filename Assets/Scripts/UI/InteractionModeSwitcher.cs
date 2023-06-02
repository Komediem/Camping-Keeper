using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionModeSwitcher : MonoBehaviour
{
    public PlayerInput input;

    public GameObject virtualCursor;

    private void OnEnable()
    {
        input.SwitchCurrentActionMap("UI");

        virtualCursor.SetActive(true);
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        virtualCursor.SetActive(false);

        input.SwitchCurrentActionMap("Player");
    }
}
