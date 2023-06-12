using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Spam : MonoBehaviour
{
    public GameObject FinalEnemy;
    public NavMeshAgent agent; //navmesh
    public float TempsAnimation;
    public float DelayENDGAME;
    //public GameObject [Name Canvas Object];

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (PlayerController.Instance.SpamActive)
        {
            //Rayon laser ?
            //Animation Destruction Enemy
            //Invoke("ENDGAME", DelayENDGAME); Ajouter un invoke pour la fin du jeu
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "SpamBOX")
        {
            FinalEnemy.SetActive(true);
            Invoke("EnemyApprochPlayer", TempsAnimation);
        }
    }

    void EnemyApprochPlayer()
    {
        agent.speed = 0;
    }

    void ENDGAME()
    {
        //                                               -- Choisir entre skip next scene ou mettre un canvas fin du jeu. --
        //
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //[Name Canvas Object].SetActive(true);
    }




}
