using ClothesShop.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace ClothesShop.Dressing
{
    public class Mannequin : MonoBehaviour
    {
        public InventoryItem ClotheItem { get; private set; }
        public InventoryItem HelmetItem { get; private set; }
           
        [SerializeField] private Image _clothe;
        [SerializeField] private Image _helmet;
        
        public void UpdateSprite(ClothesLayer layer, InventoryItem item)
        {
            if (layer == ClothesLayer.Clothe)
            {
                _clothe.sprite = item.DisplaySprite;
                ClotheItem = item;
            }
            else if (layer == ClothesLayer.Helmet)
            {
                _helmet.sprite = item.DisplaySprite;
                HelmetItem = item;
            }
        }
    }
}