using UnityEngine;
using UnityEngine.InputSystem;

public class PushPull : MonoBehaviour
{
    public bool PushPullTrigger;
    public bool isPulling;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _child;
    [SerializeField] public PlayerController playerController;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        GameObject _child = this.gameObject;
    }

    void Start()
    {
        PushPullTrigger = false;
        isPulling = false;
    }

    void Update()
    {
        if (!playerController.lockMovements && !playerController.isCrouching)
        {
            PullPush();
        }
    }

    public void PullPush()
    {
        if (PushPullTrigger)
        {

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "PushPull")
        {
            PushPullTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "PushPull")
        {
            PushPullTrigger = false;
        }
    }

    public void pull()
    {
        if (playerController.IsPulling && !playerController.isCrouching)
        {
            _child.transform.SetParent(Player.transform);                   // Sets "Player" as the new parent of the child GameObject.

            playerController.speed = playerController.speed / 2f;
            playerController.jumpSpeed = 0;
        }
        else
        {
            _child.transform.SetParent(null);                              // Setting the parent to ‘null’ unparents the GameObject and turns child into a top-level object in the hierarchy

            playerController.speed = playerController.speedDefault;
            playerController.jumpSpeed = playerController.jumpDefault;
        }
    }

    public void Pull(InputAction.CallbackContext context)
    {
        if (context.performed && !playerController.isCrouching)
        {
            isPulling = true;
        }
        else if (context.canceled)
        {
            isPulling = false;
        }
    }
}
