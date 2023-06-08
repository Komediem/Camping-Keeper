using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam1ToVcam2 : MonoBehaviour
{

    #region Cam
    public GameObject VCam1;
    public GameObject VCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam1.SetActive(false);VCam2.SetActive(true);
        }
    }
}
