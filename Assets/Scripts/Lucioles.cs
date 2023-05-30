using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Lucioles : MonoBehaviour
{
    [SerializeField] private float gainValue;
    [SerializeField] private ParticleSystem fireflies;
    [SerializeField] private GameObject firefliesFog;

    private void Start()
    {
        fireflies.Play();
        this.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Bing Chilling");
            fireflies.Stop();
            firefliesFog.SetActive(false);
            PlayerMentalHealth.instance.mentalHealth += gainValue;
            this.GetComponent<BoxCollider>().enabled = false;

            if(PlayerMentalHealth.instance.mentalHealth >= PlayerMentalHealth.instance.maxMentalHealth)
            {
                PlayerMentalHealth.instance.mentalHealth = PlayerMentalHealth.instance.maxMentalHealth;
            }
        }
    }
}
