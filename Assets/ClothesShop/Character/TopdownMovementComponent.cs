using System;
using ClothesShop.Character.Utils;
using UnityEngine;

namespace ClothesShop.Character
{
    public class TopdownMovementComponent : MonoBehaviour
    {
        /// <summary>
        /// Invoked when character changes direction without moving
        /// <param name="CardinalDirection">Look direction</param>
        /// </summary>
        public event Action<CardinalDirection> OnTurn = delegate { };
        
        /// <summary>
        /// Invoked when character starts to move
        /// <param name="CardinalDirection">Movement direction</param>
        /// </summary>
        public event Action<CardinalDirection> OnMovementStart = delegate {  };
        
        /// <summary>
        /// Invoked when character stops moving
        /// </summary>
        public event Action OnMovementStop = delegate {  };
        
        public CardinalDirection CurrentLookDirection { get; private set; } = CardinalDirection.South;
        public Vector2 GridPosition => _gridPosition;
        
        [Header("References")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Controller2D _controller;
        
        [Header("Configurations")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _colliderSize;
        [SerializeField] private float _speed;

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
            
            if (IsMoving() || _lastMoveIntent == CardinalDirection.None)
                return;
            
            UpdateTargetPosition();
        }

        private bool CanMoveToPosition(Vector2 position)
        {
            return Physics2D.OverlapBox(position, Vector2.one * _colliderSize, 0f, _layerMask) == null;
        }
        
        private void UpdateTargetPosition()
        {
            var desiredTargetPos = GetTargetPosition();
            CurrentLookDirection = _lastMoveIntent;

            if (!CanMoveToPosition(desiredTargetPos))
            {
                OnTurn(CurrentLookDirection);
                return;
            }
            
            _targetPos = desiredTargetPos;
            _lerpAmount = 0f;
            OnMovementStart(CurrentLookDirection);
        }

        private Vector2Int GetTargetPosition() => (_gridPosition + _lastMoveIntent.ToVector2()).RoundToInt();
        
        private void MoveToTargetPosition()
        {
            const float minDistance = 0.0001f;
            var hasReachedTarget = Vector2.Distance(_rigidbody.position, _targetPos) <= minDistance;
            
            if (hasReachedTarget)
            {
                _gridPosition = _targetPos;
                
                if (_lastMoveIntent == CardinalDirection.None || !CanMoveToPosition(GetTargetPosition()))
                    OnMovementStop();
                else
                    UpdateTargetPosition();
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