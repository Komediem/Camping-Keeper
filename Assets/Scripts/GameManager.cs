using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> checkpoints = new();
    public GameObject checkpointsParent;
    public GameObject CurrentCheckpoint;
    public GameObject Player;

    private void Awake()
    {
        instance = this;


        for(int i = 0; i < checkpointsParent.transform.childCount; i++)
        {
            checkpoints.Add(checkpointsParent.transform.GetChild(i).gameObject);
        }

        Player = GameObject.Find("Player");
    }
    private void Update()
    {

    }

    public void Die()
    {
        if(PlayerMentalHealth.instance.mentalHealth <= PlayerMentalHealth.instance.maxMentalHealth)
        {
            // Add More thing when the player die
        }

        Respawn();
    }
    private void Respawn()
    {
        Player.GetComponent<CharacterController>().enabled = false;

        Player.transform.position = CurrentCheckpoint.transform.position; //TP Checkpoint

        Player.GetComponent<CharacterController>().enabled = true;

        PlayerMentalHealth.instance.mentalHealth = PlayerMentalHealth.instance.maxMentalHealth;
    }
}