using UnityEngine;

namespace Sound
{
    public interface ISoundObserver
    {
        SoundType SoundType { get; }
        AudioSource Source { get; }
    }
}