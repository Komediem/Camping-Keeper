using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFeedbacks : MonoBehaviour
{
    private CharacterController characterController;
    private PickableNextLevel pickable;

    [SerializeField] private Light lanternLight;
    private bool lanternLightBool;

    [SerializeField] private GameObject stepParticle;
    [SerializeField] private GameObject fallParticle;
    [SerializeField] private Transform stepPosition;

    [SerializeField] private Rigidbody lanternRb;

    public void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
        pickable = FindObjectOfType<PickableNextLevel>();
        lanternLight = GetComponentInChildren<Light>();
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
}
