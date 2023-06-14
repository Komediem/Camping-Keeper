using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginStunActivation : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Instance.readyToStun = true;
    }
}
