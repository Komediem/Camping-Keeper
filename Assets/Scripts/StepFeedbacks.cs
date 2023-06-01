using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFeedbacks : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private GameObject stepParticle;
    [SerializeField] private Transform stepPosition;
    private GameObject particle;

    public void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    public void StepEffets()
    {
        if(characterController.isGrounded)
        {
            particle = Instantiate(stepParticle, stepPosition.position, Quaternion.identity);
            Destroy(particle, 1);
        }
    }
}
