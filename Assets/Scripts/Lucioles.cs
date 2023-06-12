using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.VFX;

public class Lucioles : MonoBehaviour
{
    [SerializeField] private float gainValue;

    [SerializeField] private VisualEffect fireflies;
    [SerializeField] private AudioSource firefliesSound;

    private bool trigger;

    private void Start()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        firefliesSound = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        fireflies.SetBool("Trigger", trigger);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Bing Chilling");
            trigger = true;
            firefliesSound.Play();
            PlayerMentalHealth.instance.mentalHealth += gainValue;
            this.GetComponent<BoxCollider>().enabled = false;

            if(PlayerMentalHealth.instance.mentalHealth >= PlayerMentalHealth.instance.maxMentalHealth)
            {
                PlayerMentalHealth.instance.mentalHealth = PlayerMentalHealth.instance.maxMentalHealth;
            }
        }
        else
        {
            trigger = false;
        }
    }
}
