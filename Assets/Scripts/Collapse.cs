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

    [SerializeField] private AudioClip Fall;
    [SerializeField] private AudioClip OnCollapse;
    [SerializeField] private AudioSource Sound;

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
            Sound.PlayOneShot(OnCollapse);
            yield return new WaitForSeconds(Timing);
            Sound.PlayOneShot(Fall);
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
