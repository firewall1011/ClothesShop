using ClothesShop.Character;
using ClothesShop.Shop;
using UnityEngine;

namespace ClothesShop.Dressing
{
    public class Wardrobe : MonoBehaviour, IInteractable
    {
        [SerializeField] private WardrobeUI _uiPrefab;
        
        public void Interact(GameObject instigator)
        {
            if (instigator.TryGetComponent(out InventoryComponent inventory) && instigator.TryGetComponent(out Controller2D controller))
            {
                var uiInstance = Instantiate(_uiPrefab);
                
                uiInstance.Open(inventory, () => controller.EnableActions());
                controller.DisableActions();
            }
        }
    }
}
