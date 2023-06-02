using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCheck : MonoBehaviour
{
    public GameObject MainMenu;

    private void Awake()
    {
        MainMenu.SetActive(false);
    }
}
