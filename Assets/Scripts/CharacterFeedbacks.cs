using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CharacterFeedbacks : MonoBehaviour
{
    private CharacterController characterController;
    private PickableNextLevel pickable;

    [SerializeField] private VisualEffect stepParticle;
    [SerializeField] private GameObject fallParticle;
    [SerializeField] private Transform stepPosition;

    [SerializeField] private Animator blackScreenTransition;

    [SerializeField] private Rigidbody lanternRb;

    [SerializeField] private ParticleSystem[] stepParticles;

    public void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
        pickable = FindObjectOfType<PickableNextLevel>();
        stepParticles = GetComponentsInChildren<ParticleSystem>();
    }

    public void StepEffets()
    {
        if(characterController.isGrounded)
        {
            /*VisualEffect particle = Instantiate(stepParticle, stepPosition.position, Quaternion.identity);
            particle.Play();
            Destroy(particle, 1);*/
        }
    }

    public void FootStepsEvent_L()
    {
        if (characterController.isGrounded)
        {
            stepParticles[0].Play();
        }

    }

    public void FootStepsEvent_R()
    {
        if (characterController.isGrounded)
        {
            stepParticles[1].Play();
        }
    }

    public void FallEffect()
    {
        GameObject particleFall = Instantiate(fallParticle, stepPosition.position, Quaternion.Euler(-90, 0, 0));
        Destroy(particleFall, 1);
    }

    public void DespawnModel()
    {
        pickable.model.SetActive(false);
    }

    public void DeathRespawn()
    {
        GameManager.instance.Respawn();
    }

    public void BlackscreenFade()
    {
        blackScreenTransition.SetBool("transiActive", true);
        blackScreenTransition.SetBool("transiActive", false);
    }
}
