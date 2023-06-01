using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFeedbacks : MonoBehaviour
{
    [SerializeField] private ParticleSystem stepParticle;
    [SerializeField] private Transform stepPosition;


    public void StepEffets()
    {
        ParticleSystem particle = Instantiate(stepParticle, stepPosition.position, Quaternion.identity);
        Destroy(particle, 1f);
    }
}
