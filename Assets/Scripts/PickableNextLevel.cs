using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickableNextLevel : MonoBehaviour
{
    public Animator animator;
    public float TempsPickupAnimation;

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pickable")
        {
            animator.SetBool("IsPicking", true);
            Invoke("NextLevel", TempsPickupAnimation);
        }
    }
}
