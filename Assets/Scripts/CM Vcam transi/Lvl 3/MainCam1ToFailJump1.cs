using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam1ToFailJump1 : MonoBehaviour
{

    #region Cam
    public GameObject MainVCam1;
    public GameObject FailVCam;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam1.SetActive(false);
            FailVCam.SetActive(true);
        }
    }
}
