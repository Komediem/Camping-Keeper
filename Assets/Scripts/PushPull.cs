using UnityEngine;
using UnityEngine.InputSystem;

public class PushPull : MonoBehaviour
{
    public bool PushPullTrigger;

    [Header("Don't need to assign :")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _child;
    private PlayerController playerController;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        _child = this.gameObject;
    }

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        PushPullTrigger = false;
    }

    void Update()
    {
        if (!PlayerController.Instance.lockMovements && !PlayerController.Instance.isCrouching)
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
        if (collision.CompareTag("Player"))
        {
            PushPullTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PushPullTrigger = false;
        }
    }

    public void pull()
    {
        if (playerController.isPulling && !playerController.isCrouching)
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
}
