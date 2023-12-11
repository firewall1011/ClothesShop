using UnityEngine;

namespace ClothesShop.Animation
{
    [CreateAssetMenu(fileName = "SpriteAnimationData", menuName = "ClothesShop/AnimationData")]
    public class SpriteAnimationData : ScriptableObject
    {
        [SerializeField] private Sprite[] _southSprites;
        [SerializeField] private Sprite[] _northSprites;
        [SerializeField] private Sprite[] _eastSprites;
        [SerializeField] private Sprite[] _westSprites;

        public Sprite[] GetSprites(CardinalDirection direction)
        {
            return direction switch
            {
                CardinalDirection.North => _northSprites,
                CardinalDirection.South => _southSprites,
                CardinalDirection.East => _eastSprites,
                CardinalDirection.West => _westSprites,
                _ => _southSprites
            };
        }
    }
}