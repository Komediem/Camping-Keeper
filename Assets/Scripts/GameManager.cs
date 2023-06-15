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
    public Checkpoint checkpointInstance;

    [SerializeField] private float deathAnimTime;

    private void Awake()
    {
        instance = this;


        for(int i = 0; i < checkpointsParent.transform.childCount; i++)
        {
            checkpoints.Add(checkpointsParent.transform.GetChild(i).gameObject);
        }

        Player = GameObject.Find("Player");
    }

    public void Die()
    {
        PlayerController.Instance.playerAnimator.SetTrigger("isDead");
    }
    public void Respawn()
    {
        Player.GetComponent<CharacterController>().enabled = false;

        Player.transform.position = CurrentCheckpoint.transform.position; //TP Checkpoint

        Player.GetComponent<CharacterController>().enabled = true;

        PlayerMentalHealth.instance.mentalHealth = PlayerMentalHealth.instance.maxMentalHealth;

        PlayerController.Instance.playerAnimator.SetTrigger("isRespawning");
    }
}