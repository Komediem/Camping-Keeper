using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFeedbacks : MonoBehaviour
{
    [SerializeField] private GameObject stepParticle;
    [SerializeField] private Transform stepPosition;
    private GameObject particle;

    public void StepEffets()
    {
        particle = Instantiate(stepParticle, stepPosition.position, Quaternion.identity);
        Destroy(particle, 1);
    }
}
