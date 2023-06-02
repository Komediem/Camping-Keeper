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
            tutoText.text = "Press " + "E" + " to Jump";
            StartCoroutine(tutoTextSpawn());
        }

        if(other.CompareTag("TutoPushPull"))
        {
            tutoText.text = "Hold " + "Z" + " to Push";
            StartCoroutine(tutoTextSpawn());
        }

        if(other.CompareTag("TutoCrouch"))
        {
            tutoText.text = "Press " + "C" + " to Crouch";
            StartCoroutine(tutoTextSpawn());
        }

        if(other.CompareTag("TutoInteract"))
        {
            tutoText.text = "Press " + "E" + " to Interact";
            StartCoroutine(tutoTextSpawn());
        }
    }

    IEnumerator tutoTextSpawn()
    {
        tutoTextObject.SetActive(true);
        yield return new WaitForSeconds(3);
        tutoTextObject.SetActive(false);
    }
}
