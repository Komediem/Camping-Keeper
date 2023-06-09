using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump1ToMainCam1 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam1;
    public GameObject VCamJump1;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam1.SetActive(true);
            VCamJump1.SetActive(false);
        }
    }
}
