using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Dust : VFX_Manager
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Dust != null) Dust.Play();
        }
    }
}
