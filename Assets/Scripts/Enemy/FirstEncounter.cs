using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstEncounter : MonoBehaviour
{
    public GameObject enemy;

    private bool readyToStun;

    [SerializeField] private float timeSpawn;
    [SerializeField] private GameObject tutoStun;
    [SerializeField] private Animator tutoStunAnimator;

    [SerializeField] private AudioSource noise;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            noise.Play();
            Invoke("EnemySpawn", timeSpawn);
            Invoke("EnemySlowed", timeSpawn + 1);
        }
    }

    private void EnemySpawn()
    {
        enemy.SetActive(true);
    }

    private void EnemySlowed()
    {
        tutoStun.SetActive(true);
        Time.timeScale = 0.25f;

        readyToStun = true;
    }
}
