using JetBrains.Annotations;
using UnityEngine;

public class Interraction : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject OutlineObject;

    //private PushPull pushPull;

    private bool obstacle = false;

    private void Awake()
    {
        //pushPull = GetComponentInParent<PushPull>();
    }

    private void Update()
    {
        //CheckCollisions();

        if (PlayerController.Instance.isJumping || PlayerController.Instance.isPulling 
            || PlayerController.Instance.isCrouching || GameManager.instance.checkpointInstance.CheckpointIsActivate)
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
        if (collision.CompareTag("Obstacle"))
        {
            obstacle = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            OutlineObject.SetActive(false);
        }

        /*if (collision.CompareTag("Obstacle")) //why is it always active ?
        {
            obstacle = false;
        }*/
    }

    public void CheckCollisions()
    {
        if (obstacle)
        {
            print("A");
        }
        else
        {
            print("B");
        }
    }
}
