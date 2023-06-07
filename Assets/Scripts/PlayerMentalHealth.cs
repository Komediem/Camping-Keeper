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
    public float minMentalHealth;

    [Header("Vignette")]
    [SerializeField] private Volume volume;
    [SerializeField] private Vignette blackVignette;

    private void Awake()
    {
        instance = this;

        maxMentalHealth = 0;
        minMentalHealth = -100;
        mentalHealth = maxMentalHealth;
    }

    private void Start()
    {
        volume = FindObjectOfType<Volume>();
        volume.profile.TryGet(out blackVignette);
    }

    public void TakeDamage(int amount)
    {
        mentalHealth -= amount;
    }

    public void Death()
    {
        PlayerController.Instance.playerAnimator.SetBool("isDead", true);
    }

    private void Update()
    {
        blackVignette.intensity.value = -mentalHealth / 100;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if(mentalHealth <= minMentalHealth)
        {
            Death();
        }
    }
}
