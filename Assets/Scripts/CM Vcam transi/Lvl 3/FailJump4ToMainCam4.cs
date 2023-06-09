using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailJump4ToMainCam4 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam4;
    public GameObject FailJumpCam4;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam4.SetActive(true);
            FailJumpCam4.SetActive(false);
        }
    }
}
