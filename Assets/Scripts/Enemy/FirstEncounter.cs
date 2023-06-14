using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEncounter : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private GameObject Trigger;
    [SerializeField] private float timeSpawn;

    [SerializeField] private AudioSource noise;

    private void Awake()
    {
        Trigger = this.gameObject;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            noise.Play(); //Jouer anim de la caméra
            Invoke("EnemySpawn", timeSpawn);
        }
    }

    private void EnemySpawn()
    {
        enemy.SetActive(true);
    }

    private void DisableBox()
    {
        Trigger.SetActive(false);
    }


    //SFX brindille + petits délais + Tuto + ralentissement        + faire disparaître pour ce cas là.
}
