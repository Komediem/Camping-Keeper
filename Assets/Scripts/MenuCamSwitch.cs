using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamSwitch : MonoBehaviour
{

    #region Cam
    public GameObject VCamMenu;
    public GameObject MainvCam1;
    #endregion

    public void VCamSwitch()
    {
        VCamMenu.SetActive(false);
        MainvCam1.SetActive(true);
    }
}
