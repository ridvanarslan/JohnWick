using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapon
{
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Vector2 audioPitch;

        private Queue<AudioSource> _pooledAudioSource;
        private GameObject _audioSourcePoolParent;

        private void Awake()
        {
            _audioSourcePoolParent = new GameObject("AudioSources");
            AudioSourcePool();
        }

        private void OnDisable()
        {
            Destroy(_audioSourcePoolParent);
        }

        private void AudioSourcePool()
        {
            _pooledAudioSource = new Queue<AudioSource>();

            for (int i = 0; i < 10; i++)
            {
                var audioSrc = Instantiate(audioSource, _audioSourcePoolParent.transform);
                audioSrc.name = $"Ses {i}";
                audioSrc.gameObject.SetActive(false);
                _pooledAudioSource.Enqueue(audioSrc);
            }
        }

        public void PlayFireSound(AudioClip gunShotClip)
        {
            //Gets AudioSource from ObjectPool Queue
            var audioSrc = _pooledAudioSource.Dequeue();
            audioSrc.gameObject.SetActive(true);
            
            //Adds clip to AudioSource
            audioSrc.clip = gunShotClip;

            
            if (audioSrc != null && audioSrc.outputAudioMixerGroup != null &&
                audioSrc.outputAudioMixerGroup.audioMixer != null)
            {
                // --- Change pitch to give variation to repeated shots ---
                audioSrc.outputAudioMixerGroup.audioMixer.SetFloat("Pitch",
                    Random.Range(audioPitch.x, audioPitch.y));
                audioSrc.pitch = Random.Range(audioPitch.x, audioPitch.y);

                // --- Play the gunshot sound ---
                Debug.Log("Ses Oynatıldı " + audioSrc.name);
                audioSrc.PlayOneShot(gunShotClip);
                _pooledAudioSource.Enqueue(audioSrc);
            }

        }
    }
}