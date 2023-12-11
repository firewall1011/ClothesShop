using UnityEngine;

namespace ClothesShop.Shop
{
    [CreateAssetMenu(menuName = "Create " + nameof(Shop), fileName = "Shop", order = 0)]
    public class Shop : ScriptableObject
    {
        [SerializeField] private InventoryData _inventory;
        [SerializeField] private ShopUI _shopUIPrefab;

        private ShopUI _shopInstance;
        
        public void Open(InventoryComponent clientInventory)
        {
            _shopInstance = Instantiate(_shopUIPrefab);
            _shopInstance.Open(_inventory);
            _shopInstance.SetClient(clientInventory);
        }

        public void Close()
        {
            _shopInstance.Close();
        }
    }
}