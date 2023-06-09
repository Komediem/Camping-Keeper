using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailJump4ToMainCam5 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam5;
    public GameObject FailJumpCam4;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam5.SetActive(true);
            FailJumpCam4.SetActive(false);
        }
    }
}
