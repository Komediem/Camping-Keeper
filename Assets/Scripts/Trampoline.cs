using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public BoxCollider trampoBox;

    private CharacterController controller;

    private void Awake()
    {
        controller = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            trampoBox.enabled = false;

            print("Boing Boig Dayo");
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
