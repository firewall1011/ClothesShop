using UnityEngine;

namespace ClothesShop
{
    public abstract class Controller2D : MonoBehaviour
    {
        /// <summary>
        /// Returns normalized movement direction
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetMoveDirection();
    }
}