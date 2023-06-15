using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] LandCLip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void _Footsteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    public void _Land()
    {
        AudioClip clip = GetRandomLand();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, LandCLip.Length - 1);
        audioSource.volume = Random.Range(0.15f, 0.3f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        return LandCLip[index];
    }

    private AudioClip GetRandomLand()
    {
        int index = Random.Range(0, LandCLip.Length - 1);
        audioSource.volume = Random.Range(0.14f, 0.3f);
        audioSource.pitch = Random.Range(0.85f, 1f);
        return LandCLip[index];
    }




}
