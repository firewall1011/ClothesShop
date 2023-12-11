using ClothesShop.Character;
using UnityEngine;

namespace ClothesShop.Animation
{
    public class TopdownCharacterAnimator : MonoBehaviour
    {
        [SerializeField] private TopdownMovementComponent _movementComponent;
        [SerializeField] private CharacterRenderer _renderer;
        [SerializeField, Min(1)] private float _frameRate;
        [SerializeField, Min(1)] private int _framesPerAnimation;
        
        private float _elapsedTime;
        private CardinalDirection _currentDirection;

        private int GetFrameIndex(float timeElapsed) => (int) ((timeElapsed * _frameRate) % _framesPerAnimation);
        
        private void OnEnable()
        {
            _movementComponent.OnMovementStart += OnMovementStart;
            _movementComponent.OnMovementStop += OnMovementStop;
        }
        
        private void OnDisable()
        {
            _movementComponent.OnMovementStart -= OnMovementStart;
            _movementComponent.OnMovementStop -= OnMovementStop;
        }

        private void OnMovementStop()
        {
            _renderer.UpdateToIdle(_currentDirection);
            _elapsedTime = 0f;
        }

        private void OnMovementStart(CardinalDirection direction)
        {
            _currentDirection = direction;
        }

        private void Update()
        {
            if (!_movementComponent.IsMoving())
                return;
            
            UpdateAnimation();
        }
        
        private void UpdateAnimation()
        {
            var frameIndex = GetFrameIndex(_elapsedTime);
            _renderer.UpdateSprite(_currentDirection, frameIndex);
            _elapsedTime += Time.deltaTime;
        }
    }
}