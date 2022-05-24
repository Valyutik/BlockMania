using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlockMania.Mine.Hero.Picks
{
    [RequireComponent(typeof(AudioSource))]
    public class HitSounds : MonoBehaviour
    { 
        [SerializeField] private List<AudioClip> hitSounds = new();

        private AudioSource audioSource;

        public void Initialize()
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        // Used in the "Dig" animation clip
        public void PlayHitSound()
        {
            audioSource.clip = hitSounds[Random.Range(0, hitSounds.Count)];
            audioSource.Play();
        }
    }
}
