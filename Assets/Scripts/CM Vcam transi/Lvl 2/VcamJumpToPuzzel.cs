using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamJumpToPuzzel : MonoBehaviour
{


    #region Cam
    public GameObject VCamJump;
    public GameObject VCamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamJump.SetActive(false);
            VCamPuzzel.SetActive(true);
        }
    }
}
