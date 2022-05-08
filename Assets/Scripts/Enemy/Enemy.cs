using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour,IDamageble
    {
        [field:SerializeField] public float HealthPoint { get; set; }
        
        public void TakeDamage(float takenDamage)
        {
            HealthPoint -= takenDamage;
            Debug.Log(HealthPoint);
        }
    }
}
