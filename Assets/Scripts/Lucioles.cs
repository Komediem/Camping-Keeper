using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucioles : MonoBehaviour
{
    [SerializeField] private float gainValue;
    [SerializeField] private ParticleSystem fireflies;

    private void Start()
    {
        fireflies.Play();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Bing");
            fireflies.Stop();
            PlayerMentalHealth.instance.mentalHealth += gainValue;

            if(PlayerMentalHealth.instance.mentalHealth >= PlayerMentalHealth.instance.maxMentalHealth)
            {
                PlayerMentalHealth.instance.mentalHealth = PlayerMentalHealth.instance.maxMentalHealth;
                Debug.Log("Chilling");
            }
        }
    }
}
