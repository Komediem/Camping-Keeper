using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam3ToEndVcame : MonoBehaviour
{

    #region Cam
    public GameObject VCamEnd;
    public GameObject VCam3;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam3.SetActive(false);
            VCamEnd.SetActive(true);
        }

    }
}
