using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamToStart : MonoBehaviour
{
    #region Cam
    public GameObject MainVCam1;
    public GameObject Start;
    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainVCam1.SetActive(false);
            Start.SetActive(true);
        }
    }
}
