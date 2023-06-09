using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam5ToFailJump4 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam5;
    public GameObject FailJumpCam4;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam5.SetActive(false);
            FailJumpCam4.SetActive(true);
        }
    }
}
