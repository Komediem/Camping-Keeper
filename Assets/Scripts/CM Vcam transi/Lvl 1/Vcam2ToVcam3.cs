using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam2ToVcam3 : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCam2;
    public GameObject VCam3;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                VCam2.SetActive(false);
                VCam3.SetActive(true);
            }
            else
            {
                ok = true;
                VCam2.SetActive(true);
                VCam3.SetActive(false);
            }
        }
    }
}
