using System;

namespace ClothesShop.Shop
{
    public class Currency : IComparable<Currency>, IEquatable<Currency>
    {
        public readonly int Amount;
        
        public Currency(int amount)
        {
            Amount = amount switch
            {
                < 0 => throw new ArgumentOutOfRangeException(nameof(amount), "Cannot create negative amount Currency"),
                _ => amount
            };
        }
        
        public static Currency operator +(Currency lhs, Currency rhs)
        {
            return new Currency(lhs.Amount + rhs.Amount);
        }

        public static Currency operator -(Currency lhs, Currency rhs)
        {
            return new Currency(lhs.Amount - rhs.Amount);
        }

        public static bool operator <(Currency lhs, Currency rhs)
        {
            return lhs.Amount < rhs.Amount;
        }

        public static bool operator >(Currency lhs, Currency rhs)
        {
            return lhs.Amount > rhs.Amount;
        }
        
        public static bool operator <=(Currency lhs, Currency rhs)
        {
            return lhs.Amount <= rhs.Amount;
        }

        public static bool operator >=(Currency lhs, Currency rhs)
        {
            return lhs.Amount >= rhs.Amount;
        }

        public int CompareTo(Currency other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Amount.CompareTo(other.Amount);
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount;
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
            return Amount;
        }
    }
}