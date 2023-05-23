using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentalHealth : MonoBehaviour
{
    public static PlayerMentalHealth instance;
    
    public float mentalHealth;
    public float maxMentalHealth;

    private void Awake()
    {
        maxMentalHealth = 100;

        mentalHealth = maxMentalHealth;
        instance = this;
    }
}
