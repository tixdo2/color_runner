using DG.Tweening;
using UnityEngine;

namespace Player.Visual
{
    public class PlayerScaler : MonoBehaviour
    {
        [SerializeField] private Transform root;

        private Vector3 defaultScale;
        private float _step;

        public void Initialize(float sizeStep)
        {
            _step = sizeStep;
            defaultScale = root.localScale;
        }
        
        public void UpdateScale(int score)
        {
            var sizeMultiplier = score * _step;
            var size = defaultScale + Vector3.one * sizeMultiplier;
            root.DOScale(size, .2f);
        }
    }
}