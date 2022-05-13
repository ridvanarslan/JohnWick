using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerFireController : MonoBehaviour
    {
        private Weapon.Weapon _weapon;
        private Camera mainCamera;

        private void Awake()
        {
            _weapon = GetComponentInChildren<Weapon.Weapon>();
            mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (Input.GetButton("Fire1") && !_weapon.CanFire && _weapon.FireDelay() && _weapon.CurrentBulletAmount > 0)
            {
                Debug.Log("fire controller");
                _weapon.CanFire = true;
                Bullet.SendBullet();
            }
            else
            {
                _weapon.CanFire = false;
            }
        }
    }
}
