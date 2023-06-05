using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickableNextLevel : MonoBehaviour
{
    public Animator animator;
    public float TempsPickupAnimation;
    public GameObject model;

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pickable")
        {
            Debug.Log("Saucisse");

            model.SetActive(false);

            animator.SetBool("IsPicking", true);
            //add more option when you pick up
            Invoke("NextLevel", TempsPickupAnimation);
        }
    }
}
