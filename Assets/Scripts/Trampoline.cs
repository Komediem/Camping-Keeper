using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public BoxCollider trampoBox;

    private void Update()
    {
        if (PlayerController.Instance.canJump)
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
