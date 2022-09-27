using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerParameters", menuName = "Player/ParametersData", order = 0)]
    public class PlayerParametersData : ScriptableObject
    {
        [SerializeField] private Color startColor;
        [SerializeField] private float sizeDelta;

        public Color StartColor => startColor;
        public float SizeDelta => sizeDelta;
    }
}