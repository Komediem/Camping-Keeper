using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisable : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private GameObject Trigger;

    private void Awake()
    {
        Trigger = this.gameObject;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            enemy.SetActive(false);
            Invoke("DisableBox", 0.5f);
        }
    }

    private void DisableBox()
    {
        Trigger.SetActive(false);
    }
}
