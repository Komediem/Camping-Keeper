using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interraction : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject OutlineObject;

    private void Update()
    {
        if (PlayerController.Instance.isJumping || PlayerController.Instance.isPulling  || PlayerController.Instance.PushPullTrigger 
            || PlayerController.Instance.isCrouching  || Checkpoint.Instance.CheckpointIsActivate)
        {
            OutlineObject.SetActive(false);
        } 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            OutlineObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            OutlineObject.SetActive(false); 
        }
    }
}
