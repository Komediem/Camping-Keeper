using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFeedbacks : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private GameObject stepParticle;
    [SerializeField] private GameObject fallParticle;
    [SerializeField] private Transform stepPosition;

    public void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    public void StepEffets()
    {
        if(characterController.isGrounded)
        {
            GameObject particle = Instantiate(stepParticle, stepPosition.position, Quaternion.identity);
            Destroy(particle, 1);
        }
    }

    public void FallEffect()
    {
        GameObject particleFall = Instantiate(fallParticle, stepPosition.position, Quaternion.identity);
        Destroy(particleFall, 1);
    }
}
