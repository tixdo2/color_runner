using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputSystem : MonoBehaviour, IPlayerInput
    {
        private float _horizontalAxis;
        private PlayerInputActions _actions;

        public PlayerInputActions Actions => _actions;

        private void Awake()
        {
            _actions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void Start()
        {
            _actions.Player.Move.performed += OnMovePerformed;
            _actions.Player.Move.canceled += OnMoveCanceled;
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _horizontalAxis = 0;
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            var axis = _actions.Player.Move.ReadValue<float>();
            _horizontalAxis = Mathf.Clamp(axis, -1, 1);
        }

        public float GetHorizontalAxis()
        {
            return _horizontalAxis;
        }

        public void Enable()
        {
            _actions.Player.Enable();
        }

        public void Disable()
        {
            _actions.Player.Disable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}