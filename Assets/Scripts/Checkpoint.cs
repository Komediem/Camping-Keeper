using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool IsActivate;
    private void OnTriggerEnter(Collider collision)
    {
        if (IsActivate == true) return;
        if (collision.tag == "Player")
        {
            GameManager.instance.CurrentCheckpoint = gameObject;
            IsActivate = true;
        }
    }
}