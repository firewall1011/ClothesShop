using UnityEngine;

namespace ClothesShop.Shop
{
    public class CurrencyBagComponent : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _initialAmount;

        public Currency Currency { get; private set; }

        private void Awake()
        {
            Currency = new Currency(_initialAmount);
        }

        public bool CanSpend(Currency amount)
        {
            return Currency >= amount;
        }

        public bool TrySpend(Currency amount)
        {
            if (!CanSpend(amount))
                return false;

            Currency -= amount;
            return true;
        }

        public void AddCurrency(Currency amount)
        {
            Currency += amount;
        }
    }
}