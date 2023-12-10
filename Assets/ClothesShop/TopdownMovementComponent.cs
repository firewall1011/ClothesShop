using UnityEngine;

namespace ClothesShop
{
    public class TopdownMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Controller2D _controller;
        
        private void Update()
        {
            _rigidbody.velocity = _controller.GetMoveDirection() * _speed;
        }
    }
}
