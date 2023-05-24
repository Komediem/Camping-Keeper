using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interraction : MonoBehaviour
{
    public bool IsTrigger = false;
    [Header("GameObject")]
    public GameObject InterractTextCanvas;
    public GameObject Player;
    public GameObject Objet;
    [Header("Script")]
    public PlayerController playerController;
    public Outline Outline;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        playerController = GetComponent<PlayerController>();
    }

    public void Interract()
    {
        if (IsTrigger == true) //( && verifier si touche maintenue)
        {
            //Outline.enabled = false;
            InterractTextCanvas.SetActive(false);
            playerController.speed = playerController.speed / 2f;
            playerController.jumpSpeed = 0;
        }
        else
        {
            playerController.speed = playerController.speedDefault;
            playerController.jumpSpeed = playerController.jumpDefault;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Outline.enabled = true;
            InterractTextCanvas.SetActive(true);
            IsTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Outline.enabled = false;
            InterractTextCanvas.SetActive(false);
            IsTrigger = false;
        }
    }
}
/*
---------------------------------------------
If player is Trigger && Hold input interraction
-Hide text canvas

Put object child player until he stop holding the input

Slow the speed of the player for more realism

Player can't jump


---------------------------------------------
*/
