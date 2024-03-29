﻿using ClothesShop.Animation;
using ClothesShop.Dressing;
using UnityEngine;

namespace ClothesShop.Shop
{
    [CreateAssetMenu(menuName = "Create " + nameof(InventoryItem), fileName = "InventoryItem", order = 0)]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField, Min(0)] private int _price;
        [SerializeField] private string _displayName;
        [SerializeField] private Sprite _displaySprite;
        [SerializeField] private SpriteAnimationData _animationData;
        [SerializeField] private ClothesLayer _layer;
        
        public Currency Price => new(_price);
        public string DisplayName => _displayName;
        public Sprite DisplaySprite => _displaySprite;
        public SpriteAnimationData AnimationData => _animationData;
        public ClothesLayer Layer => _layer;
    }
}