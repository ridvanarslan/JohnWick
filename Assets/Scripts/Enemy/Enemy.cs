using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Enemy : MonoBehaviour,IDamageble
    {
        [field:SerializeField] public float HealthPoint { get; set; }

        private NavMeshAgent _navMesh;
        private EnemyAI _enemyAI;
        private EnemyAnimations _enemyAnimations;
        
        
        private void Awake()
        {
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _enemyAI = GetComponent<EnemyAI>();
            _navMesh = GetComponent<NavMeshAgent>();
        }

        public void TakeDamage(float takenDamage)
        {
            HealthPoint -= takenDamage;
            if (HealthPoint <= 0) Die();
            Debug.Log(HealthPoint);
        }

        private void Die()
        {
            Destroy(_navMesh);
            Destroy(_enemyAI);
            _enemyAnimations.DeadAnimation(true);
        }
    }
}
