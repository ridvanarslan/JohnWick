using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        private Transform _player;


        [SerializeField] float sightRange;
        [SerializeField] float attackRange;
        [SerializeField] private float walkRange;
        [SerializeField] private float attackDelayTime;
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private LayerMask grounMask;

        [SerializeField] bool playerInSight, playerInAttackRange;
        [SerializeField] bool enemyAttacked;
        
        private EnemyAnimations _enemyAnimations;


        private void Awake()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _enemyAnimations = GetComponent<EnemyAnimations>();

        }

        private void Update()
        {
            playerInSight = Physics.CheckSphere(transform.position, sightRange, playerMask);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
            
            if (!playerInSight && !playerInAttackRange) SetWalkPosition();
            if (playerInSight && !playerInAttackRange) ChasePlayer();
            
            if (playerInAttackRange)  _enemyAnimations.AttackAnimation(playerInAttackRange);
            else _enemyAnimations.AttackAnimation(playerInAttackRange);

        }

        private void SetWalkPosition()
        {
            float randomX = UnityEngine.Random.Range(-walkRange, walkRange);
            float randomZ = UnityEngine.Random.Range(-walkRange, walkRange);

            Vector3 walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, Vector3.down, 2f, grounMask))
            {
                if (walkPoint != transform.position)
                    agent.SetDestination(walkPoint);
            }


        }

        private void AttackPlayer()
        {
            if (playerInAttackRange)
            {
                transform.LookAt(_player);
                if (!enemyAttacked)
                {
                    _player.GetComponent<IDamageble>().TakeDamage(10);
                    enemyAttacked = true;
                    Invoke(nameof(ResetAttack), attackDelayTime);
                }
            }
            
        }

        private void ResetAttack()
        {
            _enemyAnimations.AttackAnimation(false);
            enemyAttacked = false;
            Debug.Log("Saldýrdi");
        }

        private void ChasePlayer()
        {
            agent.SetDestination(_player.transform.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sightRange);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }



    }
}
