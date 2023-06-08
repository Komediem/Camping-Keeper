using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastcrouch : MonoBehaviour
{
    public bool CanStand;
    public static Raycastcrouch Instance;
    public float LongueurRayCast;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
        CanStand = true;
    }
    void Update()
    {

        float raycastLength = LongueurRayCast; 
        Vector3 raycastDirection = Vector3.up; 


        Ray ray = new Ray(transform.position, raycastDirection);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, raycastLength))
        {
            CanStand = false;
            Debug.Log("Quelque chose se trouve au-dessus du GameObject !");
        }
        else
        {
            CanStand = true;
            Debug.Log("Rien au-dessus du GameObject.");
        }
    }

}
