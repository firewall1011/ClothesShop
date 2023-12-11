using System;
using System.Linq;
using ClothesShop.Dressing;
using UnityEngine;

namespace ClothesShop.Animation
{
    [Serializable]
    internal class DataRenderer
    {
        public ClothesLayer Layer;
        public SpriteRenderer Renderer;
        public SpriteAnimationData Data;

        public void Deconstruct(out SpriteAnimationData data, out SpriteRenderer renderer)
        {
            data = Data;
            renderer = Renderer;
        }
    }
    
    internal class CharacterRenderer : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _idleFrameIndex;
        [SerializeField] private DataRenderer[] _renderers;

        public void UpdateRenderers(Mannequin mannequin)
        {
            var rendererData = _renderers.FirstOrDefault(data => data.Layer == ClothesLayer.Clothe);
            if (rendererData != null) 
                rendererData.Data = mannequin.ClotheItem.AnimationData;

            rendererData = _renderers.FirstOrDefault(data => data.Layer == ClothesLayer.Helmet);
            if (rendererData != null) 
                rendererData.Data = mannequin.HelmetItem.AnimationData;
            
            UpdateToIdle(CardinalDirection.South);
        }
        
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