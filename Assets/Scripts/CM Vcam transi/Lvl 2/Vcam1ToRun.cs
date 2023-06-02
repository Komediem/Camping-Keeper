using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam1ToRun : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCam1;
    public GameObject VCamRun;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                VCam1.SetActive(false);
                VCamRun.SetActive(true);
            }
            else
            {
                ok = true;
                VCam1.SetActive(true);
                VCamRun.SetActive(false);
            }
        }
    }
}
