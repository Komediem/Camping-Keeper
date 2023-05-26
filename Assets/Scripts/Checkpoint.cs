using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool IsActivate;
    [SerializeField] private GameObject flames;

    private void Start()
    {
        flames.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (IsActivate == true) return;
        if (collision.tag == "InterractZone")
        {
            GameManager.instance.CurrentCheckpoint = gameObject;
            IsActivate = true;

            //Activation des flammes
            flames.SetActive(true);
        }
    }
}