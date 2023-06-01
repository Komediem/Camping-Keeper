using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMentalHealth : MonoBehaviour
{
    public static PlayerMentalHealth instance;

    public float mentalHealth;
    public float maxMentalHealth;


    [SerializeField] private GameObject Vignettage;

    private void Awake()
    {
        instance = this;

        maxMentalHealth = 100;
        mentalHealth = maxMentalHealth;

       Vignettage = GameObject.Find("Vignettage");
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
        // if (mentalHealth = 90)
        // {
        //      si dmg, alors augmenter le vignettage
        // }
    }


}
