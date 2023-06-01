using UnityEngine;
using UnityEngine.InputSystem;

public class PushPull : MonoBehaviour
{
    public bool PushPullTrigger;

    [Header("Don't need to assign :")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _child;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        _child = this.gameObject;
    }

    void Start()
    {
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
            Pull();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PushPullTrigger = true;

            PlayerController.Instance.speed /= 2;
            PlayerController.Instance.speedValue /= 2;

            PlayerController.Instance.Interract.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PushPullTrigger = false;

            PlayerController.Instance.speed = PlayerController.Instance.speedDefault;
            PlayerController.Instance.speedValue = PlayerController.Instance.speedDefault;
        }
    }

    public void Pull()
    {
        if (PlayerController.Instance.isPulling && !PlayerController.Instance.isCrouching)
        {
            _child.transform.SetParent(Player.transform); // Sets "Player" as the new parent of the child GameObject.

            PlayerController.Instance.canJump = false;
            PlayerController.Instance.isCrouching = false;
        }
        else
        {
            _child.transform.SetParent(null); // Setting the parent to "null" unparents the GameObject and turns child into a top-level object in the hierarchy
        }
    }
}
