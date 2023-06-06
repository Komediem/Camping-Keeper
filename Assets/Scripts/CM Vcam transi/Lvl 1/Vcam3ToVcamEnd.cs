using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam3ToVcamEnd : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCam3;
    public GameObject VCamEnd;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                VCam3.SetActive(false);
                VCamEnd.SetActive(true);
            }
            else
            {
                ok = true;
                VCam3.SetActive(true);
                VCamEnd.SetActive(false);
            }
        }
    }
}
