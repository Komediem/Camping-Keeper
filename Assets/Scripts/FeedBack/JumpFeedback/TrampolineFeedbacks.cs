using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrampolineFeedbacks : JumpFeedbackClass
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        feedbackJumpAnimator = GetComponent<Animator>();
    }

    public override void ReturnFeedback()
    {
        feedbackJumpAnimator.SetTrigger("isBoing");
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
