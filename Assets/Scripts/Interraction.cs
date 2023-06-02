using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interraction : MonoBehaviour
{
    public bool InterractionTrigger;
    [Header("GameObject")]
    public GameObject InterractTextCanvas;
    [Header("Script")]
    public PlayerController playerController;  
    public PlayerTriggerDetection playerTriggerDetection;

    private void Start()
    {
        InterractionTrigger = false;
    }
    private void Awake()
    {
        playerTriggerDetection = GetComponent<PlayerTriggerDetection>();
    }
    private void Update()
    {
        Interract();
    }

    public void Interract()
    {
        if (playerTriggerDetection.PlayerIsTrigger == true && InterractionTrigger == true ) //( && verifier si touche maintenue)
        {
            //Outline.enabled = false;
            InterractTextCanvas.SetActive(false);

        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "InterractZone")
        {
            //Outline.enabled = true;
            InterractTextCanvas.SetActive(true);
            InterractionTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "InterractZone")
        {
            //Outline.enabled = false;
            InterractTextCanvas.SetActive(false);
            InterractionTrigger = false;
        }
    }
}
