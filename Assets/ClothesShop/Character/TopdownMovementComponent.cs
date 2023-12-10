using UnityEngine;

namespace ClothesShop
{
    public class TopdownMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Controller2D _controller;

        private Vector2Int _gridPosition;
        private Vector2Int _targetPos;
        private float _lerpAmount = 0f;
        
        private CardinalDirection _lastMoveIntent = CardinalDirection.None;
        
        private void OnEnable()
        {
            _controller.OnMoveCommand += ReceiveMoveIntent;
            _lastMoveIntent = CardinalDirection.None;
            _lerpAmount = 0f;
        }

        private void OnDisable()
        {
            _controller.OnMoveCommand -= ReceiveMoveIntent;
        }

        private void ReceiveMoveIntent(Vector2 moveDirection)
        {
            var cardinalDirection = moveDirection.ToCardinalDirection();
            _lastMoveIntent = cardinalDirection;
            
            if (_gridPosition != _targetPos)
                return;
            
            UpdateTargetPosition();
        }

        private void UpdateTargetPosition()
        {
            _targetPos = GetTargetPosition();
            _lerpAmount = 0f;
        }

        private void Update()
        {
            if (_gridPosition == _targetPos)
                return;
            
            const float minDistance = 0.001f;

            if (Vector2.Distance(_rigidbody.position, _targetPos) <= minDistance)
            {
                _gridPosition = _targetPos;
                
                if (_lastMoveIntent != CardinalDirection.None)
                {
                    UpdateTargetPosition();
                }
            }
            else
            {
                _lerpAmount += Mathf.Min(_speed * Time.deltaTime, 1f);
                var finalPos = Vector2.Lerp(_gridPosition, _targetPos, _lerpAmount);
                _rigidbody.MovePosition(finalPos);
            }
        }

        private Vector2Int GetTargetPosition() => (_gridPosition + _lastMoveIntent.ToVector2()).RoundToInt();
    }
}
