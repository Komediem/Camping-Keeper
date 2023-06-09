using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam2ToFailJump2 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam2;
    public GameObject FailJumpVCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam2.SetActive(false);
            FailJumpVCam2.SetActive(true);
        }     
    }
}
