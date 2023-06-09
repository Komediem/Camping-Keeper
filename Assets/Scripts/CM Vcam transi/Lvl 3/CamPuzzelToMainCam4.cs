using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPuzzelToMainCam4 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam4;
    public GameObject CamPuzzel;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam4.SetActive(true);
            CamPuzzel.SetActive(false);
        }
    }
}
