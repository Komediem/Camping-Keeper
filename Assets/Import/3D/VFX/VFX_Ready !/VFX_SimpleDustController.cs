using UnityEngine;
using UnityEngine.VFX;

public class VFX_SimpleDustController : MonoBehaviour
{
    [SerializeField] private VisualEffect dustVFX;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dustVFX != null) dustVFX.Play();
        }
    }
}
