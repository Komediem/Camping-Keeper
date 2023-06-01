using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeLightStun : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] public float LightRange;
    private BoxCollider colliderComponent;

    private void Awake()
    {
        colliderComponent = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        ResizeCollider();      
    }

    private void ResizeCollider()
    {
        if (colliderComponent != null)
        {
           colliderComponent.size = new Vector3(3.4f, 2.2f, LightRange);
        }
    }

}
