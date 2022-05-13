using System;
using DefaultNamespace;
using UnityEngine;

namespace Weapon
{
    public static class Bullet
    {
        public static void SendBullet()
        {
            Camera mainCamera = Camera.main;
            Debug.Log("mermi");
            if (mainCamera != null)
            {
                Ray ray = mainCamera.ViewportPointToRay(new Vector3(.5f, .5f));
                ray.origin = mainCamera.transform.position;
                if (Physics.Raycast(ray,out var hit, Mathf.Infinity))
                {
                    var hitObj = hit.collider.gameObject;
                    Debug.Log(hitObj.name);
                    if (hitObj.GetComponentInParent<IDamageble>() != null)
                    {
                        hitObj.GetComponentInParent<IDamageble>().TakeDamage(20);
                    }
                }
            }
            else
            {
                Debug.Log("kamera yok");
            }
        }
    }
}