using System;
using System.Linq;
using ClothesShop.Animation;
using ClothesShop.Shop;
using UnityEngine;

namespace ClothesShop.Dressing
{
    internal class WardrobeUI : MonoBehaviour
    {
        [SerializeField] private ClotheUI[] _clotheUIs;
        [SerializeField] private Mannequin _mannequin;
        
        private InventoryComponent _inventory;
        private Action _onCloseAction = delegate {  };
        
        public void Open(InventoryComponent inventory, Action onClose)
        {
            foreach (var item in inventory.Data.Items)
            {
                var ui = _clotheUIs.FirstOrDefault(ui => ui.Layer == item.Layer);

                if (ui != null)
                {
                    ui.AddItem(item);
                } 
            }
            
            foreach (var clotheUI in _clotheUIs)
            {
                _mannequin.UpdateSprite(clotheUI.Layer, clotheUI.CurrentItem());
                clotheUI.SetMannequin(_mannequin);
            }

            _inventory = inventory;
            _onCloseAction = onClose;
        }

        public void Close()
        {
            if (_inventory.gameObject.TryGetComponent(out CharacterRenderer characterRenderer))
            {
                characterRenderer.UpdateRenderers(_mannequin);
            }

            _onCloseAction();
            Destroy(gameObject);
        }
    }
}