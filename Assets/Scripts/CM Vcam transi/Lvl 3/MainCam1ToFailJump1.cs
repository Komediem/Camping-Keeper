using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam1ToFailJump1 : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject MainVCam1;
    public GameObject FailVCam;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                MainVCam1.SetActive(false);
                FailVCam.SetActive(true);
            }
            else
            {
                ok = true;
                MainVCam1.SetActive(true);
                FailVCam.SetActive(false);
            }
        }
    }
}
