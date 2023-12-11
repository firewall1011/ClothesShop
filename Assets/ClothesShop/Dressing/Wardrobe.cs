using ClothesShop.Shop;
using UnityEngine;

namespace ClothesShop.Dressing
{
    public class Wardrobe : MonoBehaviour, IInteractable
    {
        [SerializeField] private WardrobeUI _uiPrefab;
        
        public void Interact(GameObject instigator)
        {
            if (instigator.TryGetComponent(out InventoryComponent inventory))
            {
                var uiInstance = Instantiate(_uiPrefab);
                uiInstance.Open(inventory);
            }
        }
    }
}
