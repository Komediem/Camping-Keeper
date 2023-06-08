using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamRunToJump : MonoBehaviour
{

    #region Cam
    public GameObject VCamRun;
    public GameObject VCamJump;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamRun.SetActive(false);
            VCamJump.SetActive(true);
        }
    }
}
