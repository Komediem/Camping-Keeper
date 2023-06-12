using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Dust : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
}
