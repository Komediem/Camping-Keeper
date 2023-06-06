using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam1TovCam1Jump : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject MainVCam1;
    public GameObject VCamJump1;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                MainVCam1.SetActive(false);
                VCamJump1.SetActive(true);
            }
            else
            {
                ok = true;
                MainVCam1.SetActive(true);
                VCamJump1.SetActive(false);
            }
        }
    }
}
