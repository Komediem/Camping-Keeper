using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Spam : MonoBehaviour
{
    public static Spam Instance;

    public GameObject FinalEnemy;
    public GameObject OutlineKID;
    public GameObject LightENDGAME;
    public float DelayENDGAME;
    public bool NoCD = false;
    public GameObject Final_Cam;

    public Animator StunSpamAnimator;
    public GameObject StunSpamText;
    public GameObject whitescreen;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        LightENDGAME.SetActive(false);
        FinalEnemy = GameObject.Find("FinalEnemy");
        OutlineKID = GameObject.Find("LittleGirlOutline");
        FinalEnemy.SetActive(false);
        OutlineKID.SetActive(false);    

        StunSpamAnimator = StunSpamText.GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (PlayerController.Instance.SpamActive)
        {
            LightENDGAME.SetActive(true);
            whitescreen.SetActive(true);
            //Animation Destruction Enemy
            Invoke("ENDGAME", DelayENDGAME); 
        }
        if (NoCD && !PlayerController.Instance.SpamEND)
        {
            //SpamInputFeedbackTUTO
            PlayerController.Instance.cooldownDuration = 0;
        }
        if (PlayerController.Instance.SpamEND)
        {
            PlayerController.Instance.cooldownDuration = 100;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "SpamBOX")
        {
            StunSpamText.SetActive(true);
            PlayerController.Instance.lockMovements = true;
            OutlineKID.SetActive(false);
            NoCD = true;
            FinalEnemy.SetActive(true);
            Final_Cam.SetActive(true);
        }
    }

    void ENDGAME()
    {
        //                                               -- Choisir entre skip next scene ou mettre un canvas fin du jeu. --
        //
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //[Name Canvas Object].SetActive(true);
    }




}
