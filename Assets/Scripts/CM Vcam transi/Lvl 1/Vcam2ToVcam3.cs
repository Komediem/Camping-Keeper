using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam3To2Vcame : MonoBehaviour
{

    #region Cam
    public GameObject VCam2;
    public GameObject VCam3;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCam2.SetActive(false);
            VCam3.SetActive(true);
        }

    }
}
