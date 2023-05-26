using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPull : MonoBehaviour
{
    public bool PushPullTrigger;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _child;
    [SerializeField] public PlayerController playerController;


    void Start()
    {
        PushPullTrigger = false;
    }
    private void Awake()
    {
        Player = GameObject.Find("Player");
        GameObject _child = this.gameObject;

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

    public void pull()
    {
        if (IsPulling == true)
        {
            _child.transform.SetParent(Player.transform); // Sets "Player" as the new parent of the child GameObject.
            playerController.speed = playerController.speed / 2f;
            playerController.jumpSpeed = 0;
        }
        else
        {
            _child.transform.SetParent(null);        // Setting the parent to ‘null’ unparents the GameObject and turns child into a top-level object in the hierarchy
            playerController.speed = playerController.speedDefault;
            playerController.jumpSpeed = playerController.jumpDefault;
        }
    }


}


