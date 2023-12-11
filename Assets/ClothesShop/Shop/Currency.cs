using System;

namespace ClothesShop.Shop
{
    public class Currency : IComparable<Currency>, IEquatable<Currency>
    {
        private readonly int _amount;
        
        public Currency(int amount)
        {
            _amount = amount switch
            {
                < 0 => throw new ArgumentOutOfRangeException(nameof(amount), "Cannot create negative amount Currency"),
                _ => amount
            };
        }
        
        public static Currency operator +(Currency lhs, Currency rhs)
        {
            return new Currency(lhs._amount + rhs._amount);
        }

        public static Currency operator -(Currency lhs, Currency rhs)
        {
            return new Currency(lhs._amount - rhs._amount);
        }

        public static bool operator <(Currency lhs, Currency rhs)
        {
            return lhs._amount < rhs._amount;
        }

        public static bool operator >(Currency lhs, Currency rhs)
        {
            return lhs._amount > rhs._amount;
        }
        
        public static bool operator <=(Currency lhs, Currency rhs)
        {
            return lhs._amount <= rhs._amount;
        }

        public static bool operator >=(Currency lhs, Currency rhs)
        {
            return lhs._amount >= rhs._amount;
        }

        public int CompareTo(Currency other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return _amount.CompareTo(other._amount);
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _amount == other._amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency)obj);
        }

        public override int GetHashCode()
        {
            return _amount;
        }
    }
}