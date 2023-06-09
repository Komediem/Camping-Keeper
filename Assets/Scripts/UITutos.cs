using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITutos : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private GameObject tutoTextObject;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TutoJump"))
        {
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoPushPull"))
        {
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoCrouch"))
        {
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoInteract"))
        {
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator tutoTextSpawn()
    {
        tutoTextObject.SetActive(true);
        yield return new WaitForSeconds(3);
        tutoTextObject.SetActive(false);
    }
}
