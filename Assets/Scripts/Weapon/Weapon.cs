using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        //Audio
        [SerializeField] private AudioClip gunShotClip;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Vector2 audioPitch;

        [SerializeField] private GameObject muzzlePrefab;
        [SerializeField] private GameObject muzzlePosition;

        [SerializeField] private bool canFire;
        [SerializeField] private float shotDelay;
        
        private float currentTime;

        public bool CanFire
        {
            get { return canFire; }
            set { canFire = value; }
        }
        private void Awake()
        {
            if (audioSource != null)
            {
                audioSource.clip = gunShotClip;
            }
            currentTime = 0;
        }

        private void Update()
        {
            if (canFire && FireDelay())
            {
                Debug.Log("weapon");
                Fire();
            }
        }

        private void Fire()
        {
            currentTime = Time.time;

            var muzzleFlash = Instantiate(muzzlePrefab, muzzlePosition.transform);

            if (audioSource != null)
            {
                AudioSource newAudioSource = Instantiate(audioSource, this.transform);
                if (newAudioSource != null && newAudioSource.outputAudioMixerGroup != null && newAudioSource.outputAudioMixerGroup.audioMixer != null)
                {
                    // --- Change pitch to give variation to repeated shots ---
                    newAudioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch",
                        Random.Range(audioPitch.x, audioPitch.y));
                    newAudioSource.pitch = Random.Range(audioPitch.x, audioPitch.y);

                    // --- Play the gunshot sound ---
                    newAudioSource.PlayOneShot(gunShotClip);
                }
                Destroy(newAudioSource,1);
            }
        }

        public bool FireDelay()
        {
            if (currentTime + shotDelay <= Time.time)
                return true;
            else
                return false;
        }
    }
}