using UnityEngine;
using UnityEngine.AI;

public class LightHIT : MonoBehaviour
{
    public NavMeshAgent agent; //navmesh
    private float SpeedDefault = 0;
    public float StunDuration;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SpeedDefault = agent.speed;
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
    }

    public void StopStun()
    {
        agent.speed = SpeedDefault;
    }
}
