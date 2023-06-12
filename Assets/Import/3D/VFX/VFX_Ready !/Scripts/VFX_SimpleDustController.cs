using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]

public class VFX_SimpleDustController : MonoBehaviour
{
    [SerializeField] private VisualEffect dustVFX;

    private void Start()
    {
        dustVFX = GetComponent<VisualEffect>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dustVFX != null) dustVFX.Play();
        }
    }
}
