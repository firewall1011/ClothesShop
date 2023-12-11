using System.Collections.Generic;
using ClothesShop.Shop;
using UnityEngine;

namespace ClothesShop.Dressing
{
    internal class ClotheUI : MonoBehaviour
    {
        [field: SerializeField] public ClothesLayer Layer { get; private set; }
        
        private readonly List<InventoryItem> _items = new ();
        private int _currentIndex;
        private Mannequin _mannequin;
        
        public void AddItem(InventoryItem item)
        {
            _items.Add(item);
        }

        public void SetMannequin(Mannequin mannequin)
        {
            _mannequin = mannequin;
        }

        public InventoryItem CurrentItem()
        {
            return _items[_currentIndex];
        }
        
        public void NextItem()
        {
            _currentIndex = (_currentIndex + 1) % _items.Count;
            var item = _items[_currentIndex];
            _mannequin.UpdateSprite(Layer, item);
        }
        
        public void PreviousItem()
        {
            _currentIndex--;
            
            if (_currentIndex < 0)
                _currentIndex = _items.Count - 1;
            
            var item = _items[_currentIndex];
            _mannequin.UpdateSprite(Layer, item);
        }
    }
}