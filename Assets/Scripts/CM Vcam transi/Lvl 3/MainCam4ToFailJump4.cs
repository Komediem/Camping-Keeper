using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam4ToFailJump4 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam4;
    public GameObject FailJumpCam4;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam4.SetActive(false);
            FailJumpCam4.SetActive(true);
        }
    }
}
