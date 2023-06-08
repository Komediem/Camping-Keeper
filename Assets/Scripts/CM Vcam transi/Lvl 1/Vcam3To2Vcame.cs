using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam2ToVcam3 : MonoBehaviour
{

    #region Cam
    public GameObject VCam2;
    public GameObject VCam3;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam2.SetActive(true);
            VCam3.SetActive(false);
        }

    }
}
