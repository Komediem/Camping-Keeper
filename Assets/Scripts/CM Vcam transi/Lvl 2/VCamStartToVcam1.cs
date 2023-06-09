using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamStartToVcam1 : MonoBehaviour
{
    #region Cam
    public GameObject VCam1;
    public GameObject VCamStart;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam1.SetActive(true);
            VCamStart.SetActive(false);

        }
    }
}
