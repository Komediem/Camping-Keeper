using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam5ToFilleCam : MonoBehaviour
{
    #region Cam
    public GameObject VCamFille;
    public GameObject MainVCam5;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamFille.SetActive(true);
            MainVCam5.SetActive(false);
        }
    }
}
