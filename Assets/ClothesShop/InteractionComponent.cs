using UnityEngine;
using ClothesShop.Character;
using ClothesShop.Character.Utils;

namespace ClothesShop
{
    public class InteractionComponent : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Controller2D _controller;
        [SerializeField] private TopdownMovementComponent _movementComponent;
        
        [Header("Configuration")]
        [SerializeField] private LayerMask _layerMask;
        
        private void OnEnable()
        {
            _controller.OnInteractionCommand += Interact;
        }

        private void OnDisable()
        {
            _controller.OnInteractionCommand -= Interact;
        }

        private void Interact()
        {
            var lookDirection = _movementComponent.CurrentLookDirection.ToVector2();
            var position = _movementComponent.GridPosition;

            var result = Physics2D.OverlapBox(position + lookDirection, Vector2.one, 0f, _layerMask);
            if (result == null)
                return;

            if (result.attachedRigidbody.TryGetComponent(out IInteractable target))
            {
                target.Interact(gameObject);
            }
        }
    }
}
