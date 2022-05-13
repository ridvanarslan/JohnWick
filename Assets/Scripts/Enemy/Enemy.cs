using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Enemy : MonoBehaviour,IDamageble
    {
        [field:SerializeField] public float HealthPoint { get; set; }
        [SerializeField] private float maxHealth = 100;

        private NavMeshAgent _navMesh;
        private EnemyAI _enemyAI;
        private EnemyAnimations _enemyAnimations;
        
        public event Action<float> OnHealthChanged = delegate {  }; 


        private void Awake()
        {
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _enemyAI = GetComponent<EnemyAI>();
            _navMesh = GetComponent<NavMeshAgent>();
        }

        public void TakeDamage(float takenDamage)
        {
            HealthPoint -= takenDamage;
            float currentHealthPct = (float)HealthPoint / (float)maxHealth;
            OnHealthChanged(currentHealthPct);
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
