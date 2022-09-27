using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

namespace ColorSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class DecorateZone : MonoBehaviour
    {

        [SerializeField] private VisualEffect effect;
        
        [SerializeField] private DecorateMesh decorateMesh;
        [SerializeField] private UnityEvent<ColorArgs> onColorChanged;
        
        
        private ColorArgs _colors;
        public ColorArgs Color => _colors;
        public bool IsInitialized { get; private set; }
        private void Start()
        {
            UpdateColor();
        }

        private async void UpdateColor()
        {
            IsInitialized = false;
            var colors = await RandomColor.GetColor();
            _colors = colors;
            decorateMesh.ChangeColor(_colors.correct);
            effect.SetVector4("Color", _colors.correct);
            IsInitialized = true;
            onColorChanged.Invoke(_colors);
        }
    }
}