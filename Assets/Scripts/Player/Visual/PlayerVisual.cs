using System;
using System.Threading.Tasks;
using ColorSystem;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.VFX;

namespace Player.Visual
{
    [Serializable]
    public class VFX
    {
        [SerializeField] private VisualEffect effect;
        [SerializeField] private float time;

        public async void Play(bool withStop = true)
        {
            effect.Play();
            if(withStop)
            {
                await Task.Delay((int) (time * 1000));
                effect.Stop();
            }
        }

        public void ChangeColor(Color color)
        {
            effect.SetVector4("Color", color);
        }
    }
    
    public class PlayerVisual : MonoBehaviour
    {
        [SerializeField] private DecorateMesh decorateMesh;
        [SerializeField] private EmissionTick emissionTick;
        [SerializeField] private VFX effect;
        [SerializeField] private VFX colorChangeEffect;
        

        [SerializeField] private MMF_Player tickFeedback;
        

        public void ChangeColor(Color color)
        {
            decorateMesh.ChangeColor(color);
            emissionTick.ChangeColor(color);
            effect.ChangeColor(color);
            colorChangeEffect.ChangeColor(color);
            colorChangeEffect.Play(false);
        }

        public void Tick()
        {
            emissionTick.Tick();
            effect.Play();
            tickFeedback.PlayFeedbacks();
        }
    }
}