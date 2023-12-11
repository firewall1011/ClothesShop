using UnityEngine;

namespace ClothesShop.Shop
{
    public class CurrencyBagComponent : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _initialAmount;
        
        private Currency _currency;

        private void Awake()
        {
            _currency = new Currency(_initialAmount);
        }

        public bool CanSpend(Currency amount)
        {
            return _currency >= amount;
        }

        public bool TrySpend(Currency amount)
        {
            if (!CanSpend(amount))
                return false;

            _currency -= amount;
            return true;
        }

        public void AddCurrency(Currency amount)
        {
            _currency += amount;
        }
    }
}