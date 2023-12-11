using UnityEngine;

namespace ClothesShop.Shop
{
    public class InventoryComponent : MonoBehaviour
    {
        [field: SerializeField] public InventoryData Data { get; private set; }
        [field: SerializeField] public CurrencyBagComponent CurrencyBag { get; private set; }
    }
}