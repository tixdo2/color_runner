using UnityEngine;
using Zenject;

namespace Sound
{
    public class SoundObserver : MonoBehaviour, ISoundObserver
    {
        [Header("Audio")] 
        [SerializeField] private SoundType soundType;
        [SerializeField] private AudioSource audioSource;
        
        private ISoundHandler _soundHandler;

        public SoundType SoundType => soundType;
        public AudioSource Source => audioSource;

        [Inject]
        private void Construct(ISoundHandler soundHandler)
        {
            _soundHandler = soundHandler;
        }
        
        public void Play()
        {
            _soundHandler.PlaySound(this);
        }
    }
}