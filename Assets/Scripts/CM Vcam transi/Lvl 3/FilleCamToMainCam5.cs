using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilleCamToMainCam5 : MonoBehaviour
{
    #region Cam
    public GameObject VCamFille;
    public GameObject MainVCam5;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            VCamFille.SetActive(false);
            MainVCam5.SetActive(true);
        }
    }
}
