using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]

public class VFX_SimpleDustController : MonoBehaviour
{
    [SerializeField] private VisualEffect dustVFX;

    [SerializeField] BoxCollider boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
        dustVFX = GetComponent<VisualEffect>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Platform Trigger");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("That's a player on the Platform !");
            if (dustVFX != null) dustVFX.Play();
        }
    }
}
