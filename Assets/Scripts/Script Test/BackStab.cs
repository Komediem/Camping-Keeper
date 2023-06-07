using UnityEngine;

public class BackStab : MonoBehaviour
{
    public Transform player, enemy;

    void Update()
    {
        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance < 2)
        {
            //direction 
            Vector3 direction = enemy.transform.position - player.transform.position;
            direction.Normalize();

            //to see if the player and enemy are looking in the same direction
            float dot = Vector3.Dot(direction, player.transform.forward);

            //to see if the player is behind the enemy
            float dotback = Vector3.Dot(enemy.transform.forward, direction);

            //if the player is behind the enemy and looking in the same direction as them (at their back)
            if (dot > 0 && dotback > 0)
            {
                Debug.Log("Stab");
            }
            else
            {
                Debug.Log("Nope");
            }
        }
    }
}
