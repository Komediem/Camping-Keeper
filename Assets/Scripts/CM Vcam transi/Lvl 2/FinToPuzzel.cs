using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinToPuzzel : MonoBehaviour
{
    #region Cam
    public GameObject VCamFin;
    public GameObject VCamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamFin.SetActive(false);
            VCamPuzzel.SetActive(true);
        }
    }
}
