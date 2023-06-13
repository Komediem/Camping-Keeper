using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;
    [SerializeField] private ParticleSystem[] stepParticles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        stepParticles = GetComponentsInChildren<ParticleSystem>();
    }

    public void _Footsteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    public void FootStepsEvent_L()
    {
        stepParticles[0].Play();
    }

    public void FootStepsEvent_R()
    {
        stepParticles[1].Play();
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        audioSource.volume = Random.Range(0.2f, 0.4f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        return audioClip[index];
    }
}
