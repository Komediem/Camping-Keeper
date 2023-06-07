using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class PlayerMentalHealth : MonoBehaviour
{
    public static PlayerMentalHealth instance;

    public float mentalHealth;
    public float maxMentalHealth;

    [Header("Vignette")]
    [SerializeField] private Vignette blackVignette;

    private void Awake()
    {
        instance = this;

        maxMentalHealth = 100;
        mentalHealth = maxMentalHealth;

        blackVignette = FindObjectOfType<Vignette>();
    }

    private void Start()
    {
        
    }

    public void TakeDamage(int amount)
    {
        mentalHealth -= amount;
    }

    private void Update()
    {
        if (mentalHealth <= 75)
        {
            blackVignette.intensity.value = 1;
        }

        else if (mentalHealth <= 50)
        {
            blackVignette.intensity.value = 0.40f;
        }

        else if (mentalHealth <= 25)
        {
            blackVignette.intensity.value = 0.60f;
        }
    }


}
