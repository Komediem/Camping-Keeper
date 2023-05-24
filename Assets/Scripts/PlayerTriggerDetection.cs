using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerDetection : MonoBehaviour
{
    public bool PlayerIsTrigger;

    [Header("Script")]
    public Outline Outline;

    [Header("GameObject")]
    public GameObject InterractTextCanvas;

    private void Start()
    {
        PlayerIsTrigger = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Outline.enabled = true;
            Debug.Log("Player Detecté");
            InterractTextCanvas.SetActive(true);
            PlayerIsTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Outline.enabled = false;
            InterractTextCanvas.SetActive(false);
            PlayerIsTrigger = false;
        }
    }
}
