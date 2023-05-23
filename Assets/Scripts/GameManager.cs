using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> checkpoints;
    public GameObject CurrentCheckpoint;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
        CurrentCheckpoint = checkpoints[0];
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