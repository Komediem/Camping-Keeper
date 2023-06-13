using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoEnd : MonoBehaviour
{
    [SerializeField] private Animator tutoAnimatorEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutoAnimatorEnd.SetTrigger("FadeOut");
        }
    }
}
