using UnityEngine;

namespace Installers
{
    [CreateAssetMenu(fileName = "PlayerMovement", menuName = "Player/MovementData", order = 0)]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float gravity;

        public float VerticalSpeed => verticalSpeed;
        public float HorizontalSpeed => horizontalSpeed;
        public float Gravity => gravity;
    }
}