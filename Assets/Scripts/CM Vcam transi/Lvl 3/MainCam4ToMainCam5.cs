using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam4ToMainCam5 : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam5;
    public GameObject MainVCam4;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam5.SetActive(true);
            MainVCam4.SetActive(false);
        }
    }
}
