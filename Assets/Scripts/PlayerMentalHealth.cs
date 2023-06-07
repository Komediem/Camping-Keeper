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
    [SerializeField] private Volume volume;
    [SerializeField] private Vignette blackVignette;

    private void Awake()
    {
        instance = this;

        maxMentalHealth = 100;
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

    private void Update()
    {
        blackVignette.intensity.value = mentalHealth / 100;
    }


}
