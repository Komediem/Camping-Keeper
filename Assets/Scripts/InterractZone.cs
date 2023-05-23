using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InterractZone : MonoBehaviour
{
    public GameObject InterractTextCanvas;
    public OutlineScript Outline;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Outline.enabled = true;
            InterractTextCanvas.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Outline.enabled = false;
            InterractTextCanvas.SetActive(false);
        }
    }

}
