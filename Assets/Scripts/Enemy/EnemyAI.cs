using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform player;


        private void Update()
        {
            agent.SetDestination(player.position);
        }
    }
}
