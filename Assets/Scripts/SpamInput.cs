using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamInput : MonoBehaviour
{
    public float SpamAvantAction;
    public bool IsActive = false;
    public static SpamInput Instance;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }
    private void Update()
    {
        if (PlayerController.Instance.NombrePression >= SpamAvantAction)
        {

        }
    }

        
}
