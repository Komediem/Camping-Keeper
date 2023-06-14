using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstEncounter : MonoBehaviour
{
    public static FirstEncounter Instance;

    public GameObject enemy;

    public bool readyToStun;

    [SerializeField] private float timeSpawn;
    [SerializeField] private GameObject tutoStun;
    [SerializeField] private Animator tutoStunAnimator;

    [SerializeField] private AudioSource noise;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            noise.Play();
            PlayerController.Instance.lockMovements = true;
            PlayerController.Instance.playerAnimator.SetTrigger("backDefault");
            enemy.SetActive(true);
            Invoke("EnemySlowed", timeSpawn);
        }
    }

    private void EnemySlowed()
    {
        tutoStun.SetActive(true);
        Time.timeScale = 0.25f;

        readyToStun = true;
    }

    public void Stun()
    {
        Time.timeScale = 1;
        PlayerController.Instance.lockMovements = false;
        tutoStunAnimator.SetTrigger("FadeOut");
        this.gameObject.SetActive(false);
    }
}
