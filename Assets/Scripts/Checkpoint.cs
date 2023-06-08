using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool CheckpointIsActivate;
    [SerializeField] private GameObject flames;
    public static Checkpoint Instance;
    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }
    private void Start()
    {
        flames.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (CheckpointIsActivate == true) return;
        if (collision.tag == "InterractZone")
        {
            GameManager.instance.CurrentCheckpoint = gameObject;
            CheckpointIsActivate = true;

            //Activation des flammes
            flames.SetActive(true);
        }
    }
}