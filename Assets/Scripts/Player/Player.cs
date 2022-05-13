using System;
using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamageble,IHealable
    {
        [SerializeField] private float healthPoint = 100;

        public float HealthPoint
        {
            get => healthPoint;
            set => healthPoint = value;
        }
        private void Start()
        {
            UIManager.Instance.HealthPointText(healthPoint);
        }
        
        public void Heal(float heal)
        {
            HealthPoint += heal;
            UIManager.Instance.HealthPointText(healthPoint);

        }
        public void TakeDamage(float takenDamage)
        {
            HealthPoint -= takenDamage;
            UIManager.Instance.HealthPointText(healthPoint);
        }
    }
}