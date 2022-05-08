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
            if (Input.GetButton("Fire1") && !_weapon.CanFire && _weapon.FireDelay())
            {
                Debug.Log("fire controller");
                _weapon.CanFire = true;
                Ray ray = mainCamera.ViewportPointToRay(new Vector3(.5f, .5f));
                ray.origin = mainCamera.transform.position;
                if (Physics.Raycast(ray,out var hit, Mathf.Infinity))
                {
                    var hitObj = hit.collider.gameObject;
                    if (hitObj.GetComponent<IDamageble>() != null)
                    {
                        hitObj.GetComponent<IDamageble>().TakeDamage(20);
                    }
                }
            }
            else
            {
                _weapon.CanFire = false;
            }
        }
    }
}
