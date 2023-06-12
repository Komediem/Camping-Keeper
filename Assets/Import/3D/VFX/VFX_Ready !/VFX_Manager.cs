using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFX_Manager : MonoBehaviour
{
    [SerializeField] private VisualEffect Dust;
    [SerializeField] private VisualEffect AuraSpline;
    [SerializeField] private VisualEffect FireFlies;
    [SerializeField] private VisualEffect Sparks;
    [SerializeField] private VisualEffect Sparkle;
    [SerializeField] private VisualEffect Enemy;

    private void Start()
    {
        Dust = GetComponentInChildren<VisualEffect>();
    }

}
