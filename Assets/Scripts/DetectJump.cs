using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectJump : MonoBehaviour
{
    public bool cJump = false;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Untagged"))
        {
            cJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CompareTag("Untagged"))
        {
            cJump = false;
        }
    }
}
