using System;
using UnityEngine;

namespace ClothesShop.Animation
{
    [Serializable]
    internal struct DataRendererPair
    {
        public SpriteAnimationData Data;
        public SpriteRenderer Renderer;

        public void Deconstruct(out SpriteAnimationData data, out SpriteRenderer renderer)
        {
            data = Data;
            renderer = Renderer;
        }
    }
    
    internal class CharacterRenderer : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _idleFrameIndex;
        [SerializeField] private DataRendererPair[] _renderers;
        
        public void UpdateSprite(CardinalDirection direction, int frameIndex)
        {
            foreach (var (data, spriteRenderer) in _renderers)
            {
                spriteRenderer.sprite = data.GetSprites(direction)[frameIndex];
            }
        }
        
        public void UpdateToIdle(CardinalDirection direction) => UpdateSprite(direction, _idleFrameIndex);
    }
}