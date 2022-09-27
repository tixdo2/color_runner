using UnityEngine;

namespace ColorSystem
{
    public class DecorateMesh : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;

        private Material _material;
        
        private void Awake()
        {
            _material = renderer.material;
        }

        public void ChangeColor(Color color)
        {
            _material.color = color;
        }
        
    }
}