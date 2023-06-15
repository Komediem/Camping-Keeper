using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool CheckpointIsActivate;
    [SerializeField] private GameObject flames;
    public GameObject CamFocus;
    private void Awake()
    {
        GameManager.instance.checkpointInstance = this;
    }
    private void Start()
    {
        flames.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        CamFocus.SetActive(true);

        if (CheckpointIsActivate == true) return;
        if (collision.tag == "Player")
        {
            GameManager.instance.CurrentCheckpoint = gameObject;
            CheckpointIsActivate = true;

            //Activation des flammes
            flames.SetActive(true);
        }

    }

    private void onTriggerExit(Collider collision)
    {
        CamFocus.SetActive(false);
    }
}