using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam3ToMainCam2 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam3;
    public GameObject MainVCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam3.SetActive(false);
            MainVCam2.SetActive(true);
        }
    }
}
