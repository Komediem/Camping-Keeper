using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public BoxCollider trampoBox;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        if (PlayerController.Instance.canJump /*|| characterController.isGrounded*/)
        {
            trampoBox.enabled = false;

            print("Boing Boing Dayo");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            trampoBox.enabled = true;
        }
    }
}
