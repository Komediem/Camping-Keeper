using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamPuzzelToJump : MonoBehaviour
{


    #region Cam
    public GameObject VCamJump;
    public GameObject VCamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamJump.SetActive(true);
            VCamPuzzel.SetActive(false);
        }
    }
}
