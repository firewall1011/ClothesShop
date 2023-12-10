using UnityEngine;
using UnityEngine.InputSystem;
using ClothesShop.Input;

namespace ClothesShop
{
    public class PlayerController2D : Controller2D, PlayerInputActions.IInWorldActions
    {
        private Vector2 _currentMoveDirection;
        private PlayerInputActions _playerInputActions;
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.InWorld.SetCallbacks(this);
        }
        
        private void OnEnable() => _playerInputActions.InWorld.Enable();
        private void OnDisable() => _playerInputActions.InWorld.Disable();
        
        public void OnMove(InputAction.CallbackContext context)
        {
            _currentMoveDirection = context.ReadValue<Vector2>();
            InvokeMoveCommand(_currentMoveDirection);
        }

        public override Vector2 GetMoveDirection() => _currentMoveDirection;
    }
}
