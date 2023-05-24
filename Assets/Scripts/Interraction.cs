using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interraction : MonoBehaviour
{
    public bool InterractionTrigger;
    [Header("GameObject")]
    public GameObject InterractTextCanvas;
    public GameObject Player;
    public GameObject child;
    [Header("Script")]
    public PlayerController playerController;  
    public Outline Outline;
    public PlayerTriggerDetection playerTriggerDetection;

    private void Start()
    {
        InterractionTrigger = false;
    }
    private void Awake()
    {
        Player = GameObject.Find("Player");
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
            Debug.Log("Ca marche");
            child.transform.SetParent(Player.transform); // Sets "Player" as the new parent of the child GameObject.
            InterractTextCanvas.SetActive(false);
            playerController.speed = playerController.speed / 2f;
            playerController.jumpSpeed = 0;

        }
        else
        {
            child.transform.SetParent(null);        // Setting the parent to �null� unparents the GameObject and turns child into a top-level object in the hierarchy
            playerController.speed = playerController.speedDefault;
            playerController.jumpSpeed = playerController.jumpDefault;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "InterractZone")
        {
            Debug.Log("InterractZone Detect�");
            InterractionTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "InterractZone")
        {
            InterractionTrigger = false;
        }
    }
}
/*
                       |-------------------------------------------------------------------|
                       | - If player is Trigger && Hold input interraction                 |
                       |                                                                   |
                       | - Put object child player until he stop holding the input         |
                       |                                                                   |
                       | - Slow the speed of the player  & Player can't jump               |
                       |-------------------------------------------------------------------|
*/
