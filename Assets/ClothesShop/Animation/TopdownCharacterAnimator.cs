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

        private int GetFrameIndex(float timeElapsed) => (int) ((timeElapsed * _frameRate) % _framesPerAnimation);
        
        private void OnEnable()
        {
            _movementComponent.OnMovementStop += OnMovementStop;
            _movementComponent.OnTurn += OnTurn;
        }
        
        private void OnDisable()
        {
            _movementComponent.OnMovementStop -= OnMovementStop;
            _movementComponent.OnTurn -= OnTurn;
        }

        private void OnTurn(CardinalDirection direction)
        {
            _renderer.UpdateToIdle(direction);
        }

        private void OnMovementStop()
        {
            _renderer.UpdateToIdle(_movementComponent.CurrentLookDirection);
            _elapsedTime = 0f;
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
            _renderer.UpdateSprite(_movementComponent.CurrentLookDirection, frameIndex);
            _elapsedTime += Time.deltaTime;
        }
    }
}