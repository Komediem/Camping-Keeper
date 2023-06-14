using UnityEngine;

public class Interraction : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject OutlineObject;

    private void Update()
    {
        if (PlayerController.Instance.isJumping || PlayerController.Instance.isPulling || PlayerController.Instance.isCrouching 
            || PlayerController.Instance.SpamActive)
        {
            OutlineObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            OutlineObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            OutlineObject.SetActive(false);
        }
    }
}
