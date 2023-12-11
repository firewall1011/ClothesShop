using System;
using ClothesShop.Character.Utils;
using UnityEngine;

namespace ClothesShop.Character
{
    public class TopdownMovementComponent : MonoBehaviour
    {
        public event Action<CardinalDirection> OnMovementStart = delegate {  };
        public event Action OnMovementStop = delegate {  };
        
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Controller2D _controller;

        private Vector2Int _gridPosition;
        private Vector2Int _targetPos;
        private float _lerpAmount = 0f;
        
        private CardinalDirection _lastMoveIntent = CardinalDirection.None;
        
        public bool IsMoving() => _gridPosition != _targetPos;
        
        private void OnEnable()
        {
            _controller.OnMoveCommand += ReceiveMoveIntent;
            _lastMoveIntent = CardinalDirection.None;
            _lerpAmount = 0f;
        }
        
        private void OnDisable() => _controller.OnMoveCommand -= ReceiveMoveIntent;
        
        private void Update()
        {
            if (!IsMoving())
                return;

            MoveToTargetPosition();
        }


        private void ReceiveMoveIntent(Vector2 moveDirection)
        {
            var cardinalDirection = moveDirection.ToCardinalDirection();
            _lastMoveIntent = cardinalDirection;
            
            if (IsMoving())
                return;
            
            UpdateTargetPosition();
        }
        
        private void UpdateTargetPosition()
        {
            _targetPos = GetTargetPosition();
            _lerpAmount = 0f;
            OnMovementStart(_lastMoveIntent);
        }
        
        private Vector2Int GetTargetPosition() => (_gridPosition + _lastMoveIntent.ToVector2()).RoundToInt();
        
        private void MoveToTargetPosition()
        {
            const float minDistance = 0.0001f;
            var hasReachedTarget = Vector2.Distance(_rigidbody.position, _targetPos) <= minDistance;
            
            if (hasReachedTarget)
            {
                _gridPosition = _targetPos;
                
                if (_lastMoveIntent != CardinalDirection.None) 
                    UpdateTargetPosition();
                else
                    OnMovementStop();
            }
            else
            {
                _lerpAmount += Mathf.Min(_speed * Time.deltaTime, 1f);
                var finalPos = Vector2.Lerp(_gridPosition, _targetPos, _lerpAmount);
                _rigidbody.MovePosition(finalPos);
            }
        }
    }
}