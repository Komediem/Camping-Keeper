using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent; //navmesh

    public Transform player; //position player

    public LayerMask whatIsGround, whatIsPlayer; //quoi sol, quoi player

    #region Attacking
    public float timeBetweenAttacks; // CD attaque
    bool alreadyAttacked; //bool vérifie si ennemi attaque
    private Animator animator; //animator ennemi --> switch animation walk, attack 
    public float CooldownForDMG;
    public float Timer = 0;
    public int AmountDMG;
    #endregion

    #region Range
    public float sightRange, attackRange, lowdmgRange; //zone attaque / repérage joueur / zone dmg with time
    public bool playerInSightRange, playerInAttackRange, PlayerLowDmgRange; //bool vérification si joueur détecté
    #endregion

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        PlayerLowDmgRange = Physics.CheckSphere(transform.position, lowdmgRange, whatIsPlayer);

        if (playerInSightRange && !PlayerLowDmgRange &&!playerInAttackRange) ChasePlayer();
        if (playerInSightRange && PlayerLowDmgRange && !playerInAttackRange) DmgScdPlayer();
        if (playerInAttackRange && PlayerLowDmgRange && playerInSightRange) AttackPlayer();

        Timer++;
    }

   
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    private void DmgScdPlayer()
    {
        if(Timer >= CooldownForDMG)
        {
            PlayerMentalHealth.instance.TakeDamage(AmountDMG);
            Timer = 0;
        }
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move

        agent.SetDestination(transform.position);

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if (!alreadyAttacked)
        {

            ///Attack code here
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", true);
            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsWalking", true);
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange); 
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lowdmgRange);

    }
}
