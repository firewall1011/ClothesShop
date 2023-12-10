using System;
using UnityEngine;

namespace ClothesShop
{
    public abstract class Controller2D : MonoBehaviour
    {
        /// <summary>
        /// Invoked at every move input
        /// </summary>
        /// <param name="Vector2">Move direction</param>
        public event Action<Vector2> OnMoveCommand = delegate { };
        
        /// <summary>
        /// Returns normalized movement direction
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetMoveDirection();
        
        protected void InvokeMoveCommand(Vector2 moveDirection) => OnMoveCommand(moveDirection);
    }
}