using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPull : MonoBehaviour
{
    public bool PushPullTrigger;

    void Start()
    {
        PushPullTrigger = false;
    }

    void Update()
    {
        PullPush();
    }

    public void PullPush()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "PushPull")
        {
            PushPullTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "PushPull")
        {
            PushPullTrigger = false;
        }
    }


}


