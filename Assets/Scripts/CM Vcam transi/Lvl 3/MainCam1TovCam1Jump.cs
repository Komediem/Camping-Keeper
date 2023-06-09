using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam1TovCam1Jump : MonoBehaviour
{

    #region Cam
    public GameObject MainVCam1;
    public GameObject VCamJump1;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam1.SetActive(false);
            VCamJump1.SetActive(true);
        }
    }
}
