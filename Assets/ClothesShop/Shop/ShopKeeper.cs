using UnityEngine;

namespace ClothesShop.Shop
{
    public class ShopKeeper : MonoBehaviour, IInteractable
    {
        [SerializeField] private Shop _shop;

        public void Interact(GameObject instigator)
        {
            if (instigator.TryGetComponent(out InventoryComponent inventoryComp))
            {
                _shop.Open(inventoryComp);
            }
        }
    }
}