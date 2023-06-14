using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent; //navmesh

    public Transform player; //position player

    public LayerMask whatIsGround, whatIsPlayer; //quoi sol, quoi player

    [SerializeField] private VisualEffect attackEffect;

    #region Attacking
    public float timeBetweenAttacks; // CD attaque
    bool alreadyAttacked; //bool v�rifie si ennemi attaque
    private Animator animator; //animator ennemi --> switch animation walk, attack 
    [Header("Dmg With Time")]
    [Space]
    public float lowdmgRange;
    public bool PlayerDmgRange;
    public float CooldownForDMG;
    public float Timer = 0;
    public int AmountDMG;

    #endregion

    #region Range
    [Header("Spot & Attack Player")]
    [Space]
    public float sightRange; //rep�rage joueur 
    public float attackRange; //zone attaque 
    public bool playerInSightRange;  //bool v�rification si joueur d�tect�
    public bool playerInAttackRange;  //bool v�rification si joueur d�tect�
    public int BIGAmountDMG;
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
        PlayerDmgRange = Physics.CheckSphere(transform.position, lowdmgRange, whatIsPlayer);

        if (playerInSightRange && !PlayerDmgRange &&!playerInAttackRange) ChasePlayer();
        if (playerInSightRange && PlayerDmgRange && !playerInAttackRange) DmgScdPlayer();
        if (playerInAttackRange && PlayerDmgRange && playerInSightRange) AttackPlayer();

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
            attackEffect.Play();
            PlayerMentalHealth.instance.TakeDamage(BIGAmountDMG);
            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
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
