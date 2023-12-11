using UnityEngine;

namespace ClothesShop.Animation
{
    [CreateAssetMenu(fileName = "Create " + nameof(SpriteAnimationData), menuName = "ClothesShop/AnimationData")]
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

        public void SetSouthSprites(Sprite[] sprites)
        {
            _southSprites = sprites;
        }
        
        public void SetNorthSprites(Sprite[] sprites)
        {
            _northSprites = sprites;
        }
        
        public void SetEastSprites(Sprite[] sprites)
        {
            _eastSprites = sprites;
        }
        
        public void SetWestSprites(Sprite[] sprites)
        {
            _westSprites = sprites;
        }
    }
}