using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Collapse : MonoBehaviour
{

    [SerializeField] private float Timing = 2;
    [SerializeField] private float Retour = 2;

    [SerializeField] private Animator c_Animator;

    [SerializeField] private bool Touched = false;

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Touched)
        {
            StartCoroutine(CollapsePlatform());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && Touched)
        {
            StartCoroutine(CollapsePlatform());
        }
    }

    IEnumerator CollapsePlatform()
    {
        if (!Touched)
        {
            yield return new WaitForSeconds(Timing);
            c_Animator.SetBool("Activate", true);
            Touched = true;
        }

        if (Touched)
        {
            yield return new WaitForSeconds(Retour);
            c_Animator.SetBool("Activate", false);
            Touched = false;
        }
    }
}
