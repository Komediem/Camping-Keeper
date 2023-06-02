using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamJumpToPuzzel : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject VCamJump;
    public GameObject VCamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                VCamJump.SetActive(false);
                VCamPuzzel.SetActive(true);
            }
            else
            {
                ok = true;
                VCamJump.SetActive(true);
                VCamPuzzel.SetActive(false);
            }
        }
    }
}
