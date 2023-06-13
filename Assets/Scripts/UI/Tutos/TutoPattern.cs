using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPattern : MonoBehaviour
{
    [SerializeField] private GameObject tuto;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            tuto.SetActive(true);
        }
    }
}
