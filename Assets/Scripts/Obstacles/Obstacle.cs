using System.Security.Cryptography;
using ColorSystem;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private DecorateMesh decorateMesh;

        private Color _color;

        public Color Color => _color;

        public void Initialize(Color color)
        {
            _color = color;
            decorateMesh.ChangeColor(_color);
        }

        public void Delete()
        {
            Destroy(gameObject);
        }
        
    }
}