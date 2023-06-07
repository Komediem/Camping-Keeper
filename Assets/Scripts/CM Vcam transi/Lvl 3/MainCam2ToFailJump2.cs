using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam2ToFailJump2 : MonoBehaviour
{
    [SerializeField]
    private bool ok = true;

    #region Cam
    public GameObject MainVCam2;
    public GameObject FailJumpVCam2;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (ok)
            {
                ok = false;
                MainVCam2.SetActive(false);
                FailJumpVCam2.SetActive(true);
            }
            else
            {
                ok = true;
                MainVCam2.SetActive(true);
                FailJumpVCam2.SetActive(false);
            }
        }
    }
}
