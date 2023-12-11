using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClothesShop.Shop
{
    [CreateAssetMenu(menuName = "Create " + nameof(InventoryData), fileName = "InventoryData", order = 0)]
    public class InventoryData : ScriptableObject
    {
        public event Action OnInventoryUpdated = delegate {  };
        [field: SerializeField] public List<InventoryItem> Items { get; private set; } = new ();
        
        public void AddItem(InventoryItem item)
        {
            Items.Add(item);
            OnInventoryUpdated();
        }

        public bool HasItem(InventoryItem item) => Items.Contains(item);
    }
}