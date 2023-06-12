using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineFeedbacks : JumpFeedbackClass
{
    private void Awake()
    {
        feedbackJumpAnimator = GetComponent<Animator>();
    }

    public override void ReturnFeedback()
    {
        feedbackJumpAnimator.SetTrigger("isBoing");
    }
}
