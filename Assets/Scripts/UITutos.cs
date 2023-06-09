using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITutos : MonoBehaviour
{
    public static UITutos instance;

    [Header("Texts")]
    [SerializeField] private GameObject tutoTextObject;
    [SerializeField] private List<GameObject> tutoTexts = new();

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < tutoTextObject.transform.childCount; i++)
        {
            tutoTexts.Add(tutoTextObject.transform.GetChild(i).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TutoJump"))
        {
            GameObject tutoJump = tutoTexts[1];
            tutoJump.SetActive(true);
        }

        if(other.CompareTag("TutoPushPull"))
        {
            GameObject tutoPushPull = tutoTexts[2];
            tutoPushPull.SetActive(true);
        }

        if(other.CompareTag("TutoCrouch"))
        {
            GameObject tutoCrouch = tutoTexts[3];
            tutoCrouch.SetActive(true);
        }

        if(other.CompareTag("TutoInteract"))
        {
            GameObject tutoInteract = tutoTexts[4];
            tutoInteract.SetActive(true);
        }

        if (other.CompareTag("TutoStun"))
        {
            GameObject tutoStun = tutoTexts[5];
            tutoStun.SetActive(true);
        }
    }

    /*IEnumerator tutoTextSpawn()
    {
        tutoTextObject.SetActive(true);
        yield return new WaitForSeconds(3);
        tutoTextObject.SetActive(false);
    }*/

    public void TutoMovement()
    {
        GameObject tutoMovement = tutoTexts[0];
        tutoMovement.SetActive(true);
    }
}
