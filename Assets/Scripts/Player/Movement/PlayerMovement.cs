using System;
using Input;
using Installers;
using UnityEngine;
using Zenject;

namespace Player.Movement
{
    [Serializable]
    public class MovementAnimationData
    {
        [SerializeField] private string idleParameter;
        [SerializeField] private string runningParameter;

        public int IdleParameter { get; private set; }
        public int RunningParameter { get; private set; }

        public void Initialize()
        {
            IdleParameter = Animator.StringToHash(idleParameter);
            RunningParameter = Animator.StringToHash(runningParameter);
        }
    }
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerMovementData movementData;
        
        [Header("Player Components References")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;
        [SerializeField] private MovementAnimationData animationData;
        
        
        private IPlayerInput _input;
        private bool _isRunning;

        [Inject]
        private void Construct(IPlayerInput input)
        {
            _input = input;
        }

        private void Awake()
        {
            animationData.Initialize();
            _isRunning = false;
        }

        public void Enable()
        {
            _isRunning = true;
        }

        public void Disable()
        {
            _isRunning = false;
        }

        private void FixedUpdate()
        {
            if (!_isRunning) return;
            
            var movement = CalculateMovement();
            
            if (movement.magnitude > 0)
            {
                characterController.Move(movement);
                animator.SetBool(animationData.RunningParameter, true);
            }
        }

        private Vector3 CalculateMovement()
        {
            var vertical = Vector3.forward * movementData.VerticalSpeed;
            var horizontal = new Vector3(_input.GetHorizontalAxis(), 0, 0) * movementData.HorizontalSpeed;
            var gravity = Vector3.down * Mathf.Abs(movementData.Gravity);
            return (vertical + horizontal + gravity) * Time.deltaTime;
        }
        
    }
}
