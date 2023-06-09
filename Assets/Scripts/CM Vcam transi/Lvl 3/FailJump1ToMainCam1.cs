using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailJump1ToMainCam1 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam1;
    public GameObject FailVCam;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam1.SetActive(true);
            FailVCam.SetActive(false);
        }
    }
}
