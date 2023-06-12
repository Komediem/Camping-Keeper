using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickableNextLevel : MonoBehaviour
{
    public Animator animator;
    public float TempsPickupAnimation;
    public GameObject model;

    [SerializeField] private Animator blackScreenTransition;

    void NextLevel()
    {
        PlayerController.Instance.speed = PlayerController.Instance.speedDefault;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pickable")
        {
            PlayerController.Instance.lockMovements = true; 
            animator.SetBool("isPicking", true);
            //add more option when you pick up
            blackScreenTransition.SetBool("transiActive", true);
            Invoke("NextLevel", TempsPickupAnimation);
        }
    }
}
