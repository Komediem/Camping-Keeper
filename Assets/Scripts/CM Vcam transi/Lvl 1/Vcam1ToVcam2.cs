using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcam1ToVcam2 : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCam1;
    public GameObject VCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (ok)
            {
                ok = false;
                VCam1.SetActive(false);
                VCam2.SetActive(true);
            }
            else
            {
                ok = true;
                VCam1.SetActive(true);
                VCam2.SetActive(false);
            }
        }
    }
}
