using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public enum SoundType
    {
        Tick
    }

    [Serializable]
    public class SoundContainer
    {
        public SoundType sound;
        public AudioClip clip;
    }

    public class SoundHandler : MonoBehaviour, ISoundHandler
    {
        [SerializeField] private SoundContainer[] sounds;

        private Dictionary<SoundType, AudioClip> soundCollection = new ();

        private void Awake()
        {
            foreach (var soundContainer in sounds)
            {
                soundCollection.Add(soundContainer.sound, soundContainer.clip);
            }
        }
        
        public void PlaySound(ISoundObserver soundObserver)
        {
            if (!soundCollection.TryGetValue(soundObserver.SoundType, out var value)) return;
            
            if(soundObserver.Source.clip == null || soundObserver.Source.clip != value)
                soundObserver.Source.clip = value;
                
            soundObserver.Source.Play();
        }
    }
}
