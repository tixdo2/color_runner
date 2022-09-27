using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ColorSystem
{
    public class RandomColor : MonoBehaviour
    {
        [SerializeField] private Colors colors;

        private static Colors _colors;

        private void Awake()
        {
            _colors = colors;
        }

        public static async Task<ColorArgs> GetColor()
        {
            while (!_colors)
            {
                await Task.Yield();
            }
            return await _colors.GetRandomColor();
        }
    }
}