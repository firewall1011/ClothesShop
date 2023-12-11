﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothesShop.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private ItemUI _itemUIPrefab;
        [SerializeField] private Transform _itemUIContainer;
        [SerializeField] private TextMeshProUGUI _currentCurrencyTxt;
        
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

        private void Update()
        {
            if (_client == null)
                return;

            var amount = _client.CurrencyBag.Currency.Amount;
            _currentCurrencyTxt.SetText(amount.ToString("C0"));
        }
    }
}