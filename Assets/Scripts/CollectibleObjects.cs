using System;
using System.Dynamic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CollectibleObjects : MonoBehaviour
    {
        [SerializeField] private CollectibleOnjectType collectibleOnjectType;
        [SerializeField] private float amount;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject;
                switch (collectibleOnjectType)
                {
                    case CollectibleOnjectType.GivesDamage:
                        player.GetComponent<IDamageble>().TakeDamage(amount);
                        break;
                    case CollectibleOnjectType.GivesHeal:
                        player.GetComponent<IHealable>().Heal(10);
                        break;
                }
                
                Destroy(this.gameObject);
            }
        }
    }

    enum CollectibleOnjectType
    {
        GivesHeal,
        GivesDamage
    }
}