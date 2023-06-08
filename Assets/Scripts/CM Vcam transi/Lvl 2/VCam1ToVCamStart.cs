using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam1ToVCamStart : MonoBehaviour
{

    #region Cam
    public GameObject VCam1;
    public GameObject VCamStart;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam1.SetActive(false);
            VCamStart.SetActive(true);

        }
    }
}
