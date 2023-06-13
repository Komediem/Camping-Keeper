using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ENDGAMEEnemy : MonoBehaviour
{
    public float ENDGAME;
    public GameObject EnemyEND;

    private void Awake()
    {
        EnemyEND = this.gameObject;
    }

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "LightENDGAME")
        {

            Invoke("EnemyKill", ENDGAME);
        }
    }

    void EnemyKill()
    {
        Destroy(EnemyEND);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
