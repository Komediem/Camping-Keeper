using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelToFin : MonoBehaviour
{
    #region Cam
    public GameObject VCamFin;
    public GameObject VCamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamFin.SetActive(true);
            VCamPuzzel.SetActive(false);
        }
    }
}
