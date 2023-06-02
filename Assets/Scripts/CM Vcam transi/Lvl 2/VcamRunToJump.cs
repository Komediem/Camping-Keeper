using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamRunToJump : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCamRun;
    public GameObject VCamJump;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                VCamRun.SetActive(false);
                VCamJump.SetActive(true);
            }
            else
            {
                ok = true;
                VCamRun.SetActive(true);
                VCamJump.SetActive(false);
            }
        }
    }
}
