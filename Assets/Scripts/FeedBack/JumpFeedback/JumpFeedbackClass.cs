using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JumpFeedbackClass : MonoBehaviour
{
    public Animator feedbackJumpAnimator;

    public abstract void ReturnFeedback();
}
