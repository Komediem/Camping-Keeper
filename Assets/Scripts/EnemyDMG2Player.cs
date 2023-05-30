using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG2Player : MonoBehaviour
{

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMentalHealth healthComponent = collision.GetComponent<PlayerMentalHealth>();
            if (healthComponent != null)
            {
                Debug.Log(PlayerMentalHealth.instance.mentalHealth);
                healthComponent.TakeDamage(40);
            }
        }
    }
}