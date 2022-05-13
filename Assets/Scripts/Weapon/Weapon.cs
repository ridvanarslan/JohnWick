using System;
using DefaultNamespace;
using Enemy;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        //Audio
        [SerializeField] private WeaponSound weaponSound;
        [SerializeField] private AudioClip gunShotClip;

        [SerializeField] private GameObject muzzlePrefab;
        [SerializeField] private GameObject muzzlePosition;

        [SerializeField] private bool canFire;
        [SerializeField] private float shotDelay;

        [SerializeField] private short maxMagazineCapacity;
        [SerializeField] private short currentBulletAmount;
        [SerializeField] private short totalMagazineCount;
        
        private float _currentTime;

        public bool CanFire
        {
            get { return canFire; }
            set { canFire = value; }
        }

        public short CurrentBulletAmount => currentBulletAmount;

        private void Awake()
        {
            _currentTime = 0;
        }

        private void Start()
        {
            LoadMagazine();
        }

        private void Update()
        {
            if (canFire && FireDelay())
            {
                Debug.Log("weapon");
                Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                LoadMagazine();
            }
        }

        private void Fire()
        {
            _currentTime = Time.time;
            var muzzleFlash = Instantiate(muzzlePrefab, muzzlePosition.transform);
            weaponSound.PlayFireSound(gunShotClip);
            currentBulletAmount--;
            UIManager.Instance.AmmoAmountText($"{currentBulletAmount}/{totalMagazineCount}");
        }

        public bool FireDelay()
        {
            if (_currentTime + shotDelay <= Time.time)
                return true;
            else
                return false;
        }

        private void LoadMagazine()
        {
            if (totalMagazineCount > 0)
            {
                currentBulletAmount = maxMagazineCapacity;
                totalMagazineCount--;
                UIManager.Instance.AmmoAmountText($"{currentBulletAmount}/{totalMagazineCount}");
            }
        }
    }
}