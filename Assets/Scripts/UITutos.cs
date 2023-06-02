using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITutos : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI tutoText;
    [SerializeField] private GameObject tutoTextObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TutoJump"))
        {
            tutoText.text = "Press " + "Space Bar" + " to Jump";
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoPushPull"))
        {
            tutoText.text = "Hold " + "Z" + " to Push or Pull";
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoCrouch"))
        {
            tutoText.text = "Press " + "C" + " to Crouch";
            StartCoroutine(tutoTextSpawn());
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if(other.CompareTag("TutoInteract"))
        {
            tutoText.text = "Press " + "E" + " to Interact";
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
