using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginStunActivation : MonoBehaviour
{
    private void Start()
    {
        FirstEncounter.Instance.readyToStun = true;
    }
}
