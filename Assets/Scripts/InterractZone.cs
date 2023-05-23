using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InterractZone : MonoBehaviour
{
    public GameObject InterractTextCanvas; 

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            InterractTextCanvas.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            InterractTextCanvas.SetActive(false);
        }
    }

}
