using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Spam : MonoBehaviour
{
    public GameObject FinalEnemy;
    public GameObject OutlineKID;
    public GameObject LightENDGAME;
    public NavMeshAgent agent; //navmesh
    public float TempsAnimation;
    public float DelayENDGAME;
    public bool NoCD = false;
    //public GameObject [Name Canvas Object];

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        LightENDGAME.SetActive(false);
        FinalEnemy = GameObject.Find("FinalEnemy");
    }

    private void Update()
    {
        if (PlayerController.Instance.SpamActive)
        {
            LightENDGAME.SetActive(true);
            //Animation Destruction Enemy
            Invoke("ENDGAME", DelayENDGAME); 
        }

        if (NoCD)
        {
            //SpamInputFeedbackTUTO
            PlayerController.Instance.cooldownDuration = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "SpamBOX")
        {
            PlayerController.Instance.speed = 0;
            OutlineKID.SetActive(false);
            NoCD = true;
            FinalEnemy.SetActive(true);
        }
    }

    void ENDGAME()
    {
        //                                               -- Choisir entre skip next scene ou mettre un canvas fin du jeu. --
        //
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //[Name Canvas Object].SetActive(true);
    }




}
