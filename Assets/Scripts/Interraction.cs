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
        if (PlayerController.Instance.isJumping == true || PlayerController.Instance.isPulling == true || PlayerController.Instance.PushPullTrigger == true || PlayerController.Instance.isCrouching == true)
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
