using UnityEngine;

namespace ClothesShop
{
    public static class Vector2Extensions
    {
        public static CardinalDirection ToCardinalDirection(this Vector2 direction)
        {
            direction.Normalize();
            return direction == Vector2.zero 
                ? CardinalDirection.None 
                : Mathf.Abs(direction.x) > Mathf.Abs(direction.y) 
                ? direction.x > 0f ? CardinalDirection.East : CardinalDirection.West
                : direction.y > 0f ? CardinalDirection.North : CardinalDirection.South;
        }

        public static Vector2 ToVector2(this CardinalDirection direction) => direction switch
        {
            CardinalDirection.North => Vector2.up,
            CardinalDirection.South => Vector2.down,
            CardinalDirection.East => Vector2.right,
            CardinalDirection.West => Vector2.left,
            _ => Vector2.zero
        };

        public static Vector2Int RoundToInt(this Vector2 vector) => new(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
    }
}