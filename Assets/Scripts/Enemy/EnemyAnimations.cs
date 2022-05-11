using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimations : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void DeadAnimation(bool isDead) => _animator.SetBool("__isDead", isDead);
    }
}