using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPuzzelToMainCam3 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam3;
    public GameObject CamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam3.SetActive(true);
            CamPuzzel.SetActive(false);
        }
    }
}
