using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightHIT : MonoBehaviour
{
    public NavMeshAgent agent; //navmesh
    private float SpeedDefault = 0;
    public float StunDuration;

    [SerializeField] List<Material> materials = new();
    [SerializeField] SkinnedMeshRenderer monsterMesh;

    [SerializeField] Material eyesMaterial1, eyesMaterial2;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SpeedDefault = agent.speed;
        //monsterMesh.GetMaterials(materials);
        //materials.Find(Material) = eyesMaterial1;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "LightHitBox")
        {
            Stun();
            Invoke("StopStun", StunDuration);
        }
    }

    public void Stun()
    {
        agent.speed = 0;
        //monsterMesh.material = eyesMaterial2;
    }

    public void StopStun()
    {
        agent.speed = SpeedDefault;
    }
}
