using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LilypadFeedback : JumpFeedbackClass
{
    public ParticleSystem splash;

    private void Awake()
    {
        feedbackJumpAnimator = GetComponent<Animator>();
    }

    public override void ReturnFeedback()
    {
        splash.Play();
        feedbackJumpAnimator.SetTrigger("PloufTrigger");
    }
}
