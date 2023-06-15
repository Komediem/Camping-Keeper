using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LilypadFeedback : JumpFeedbackClass
{
    public ParticleSystem splash;
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        feedbackJumpAnimator = GetComponent<Animator>();
    }

    public override void ReturnFeedback()
    {
        splash.Play();
        feedbackJumpAnimator.SetTrigger("PloufTrigger");
        _Bowing();
    }

    public void _Bowing()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        audioSource.volume = Random.Range(0.2f, 0.4f);
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        return audioClip[index];
    }
}
