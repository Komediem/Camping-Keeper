using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamRunToVcam1 : MonoBehaviour
{

    #region Cam
    public GameObject VCam1;
    public GameObject VCamRun;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam1.SetActive(true);
            VCamRun.SetActive(false);

        }
    }
}
