using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothesShop.Shop
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemNameText; 
        [SerializeField] private TextMeshProUGUI _itemPriceText; 
        [SerializeField] private Image _itemRenderer;
        [SerializeField] private Button _buyButton;

        private InventoryComponent _client;
        private InventoryItem _item;
        
        public void SetItem(InventoryItem item)
        {
            _itemNameText.SetText(item.DisplayName);
            _itemPriceText.SetText(item.Price.Amount.ToString("C0"));
            _itemRenderer.sprite = item.DisplaySprite;

            _item = item;
        }

        public void SetClient(InventoryComponent client)
        {
            RemoveClient();

            _client = client;
            
            _client.Data.OnInventoryUpdated += UpdateButton;
            _buyButton.onClick.AddListener(TryBuyItem);
            
            UpdateButton();
        }

        private void RemoveClient()
        {
            if (_client)
            {
                _client.Data.OnInventoryUpdated -= UpdateButton;
                _buyButton.onClick.RemoveListener(TryBuyItem);
            }
        }

        private void OnDestroy()
        {
            RemoveClient();
        }

        private void TryBuyItem()
        {
            if (_client.CurrencyBag.TrySpend(_item.Price))
            {
                _client.Data.AddItem(_item);
            }
        }

        private void UpdateButton()
        {
            if (_client == null || _item == null)
                return;

            var clientCanBuy = _client.CurrencyBag.CanSpend(_item.Price);
            var clientHasItem = _client.Data.HasItem(_item);
            _buyButton.interactable = clientCanBuy && !clientHasItem;
        }
    }
}