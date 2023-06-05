using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vCam1JumpToMainvCam2 : MonoBehaviour
{

    #region Cam
    public GameObject VCamJump1;
    public GameObject MainVCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
                VCamJump1.SetActive(false);
                MainVCam2.SetActive(true);
        }
    }
}
