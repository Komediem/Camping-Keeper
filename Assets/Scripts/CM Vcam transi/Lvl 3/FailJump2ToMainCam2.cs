using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailJump2ToMainCam2 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam2;
    public GameObject FailJumpVCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam2.SetActive(true);
            FailJumpVCam2.SetActive(false);
        }
    }
}
