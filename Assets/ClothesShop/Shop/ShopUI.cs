using UnityEngine;
using UnityEngine.UI;

namespace ClothesShop.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private ItemUI _itemUIPrefab;
        [SerializeField] private Transform _itemUIContainer;
        
        private InventoryComponent _client;

        private void Awake() => _closeButton.onClick.AddListener(Close);
        private void OnDestroy() => _closeButton.onClick.RemoveListener(Close);

        public void Open(InventoryData inventory)
        {
            foreach (var item in inventory.Items)
            {
                var itemUI = Instantiate(_itemUIPrefab, _itemUIContainer);
                itemUI.SetItem(item);
                itemUI.SetClient(_client);
            }
        }

        public void SetClient(InventoryComponent client)
        {
            _client = client;
        }
        
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}