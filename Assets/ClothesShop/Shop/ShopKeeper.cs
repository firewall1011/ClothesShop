using ClothesShop.Character;
using UnityEngine;

namespace ClothesShop.Shop
{
    public class ShopKeeper : MonoBehaviour, IInteractable
    {
        [SerializeField] private Shop _shop;

        public void Interact(GameObject instigator)
        {
            if (instigator.TryGetComponent(out InventoryComponent inventoryComp) && instigator.TryGetComponent(out Controller2D controller))
            {
                _shop.Open(inventoryComp, () => controller.EnableActions());
                controller.DisableActions();
            }
        }
    }
}