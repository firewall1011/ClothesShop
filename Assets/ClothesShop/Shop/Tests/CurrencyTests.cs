using System;
using NUnit.Framework;

namespace ClothesShop.Shop.Tests
{
    public class CurrencyTests
    {
        [Test]
        [TestCase(0), TestCase(-0), TestCase(5), TestCase(999)]
        public void Can_Create_Currency_With_Positive_Amounts(int amount)
        {
            Assert.DoesNotThrow(() =>
            {
                var currency = new Currency(amount);
            });
        }
        
        [Test]
        [TestCase(-5), TestCase(-10), TestCase(-999)]
        public void Creating_Currency_With_Negative_Amounts_Throws_Exception(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var currency = new Currency(amount);
            });
        }

        [Test]
        public void Sum_Two_Zero_Currencies()
        {
            Sum_Two_Currencies(0, 0);
        }
        
        [Test]
        public void Sum_Two_Positive_Currencies()
        {
            Sum_Two_Currencies(5, 7);
        }
        
        [Test]
        public void Sum_Zero_With_Positive_Currencies()
        {
            Sum_Two_Currencies(0, 7);
        }

        [Test]
        public void Can_Subtract_Smaller_Currency_From_Bigger()
        {
            Subtract_Two_Currencies(10, 5);
        }
        
        [Test]
        public void Subtracting_Bigger_Currency_From_Smaller_Throws_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Subtract_Two_Currencies(1, 2));
        }
        
        [Test]
        public void Subtract_Two_Zero_Currencies()
        {
            Subtract_Two_Currencies(0, 0);
        }
        
        [Test]
        public void Subtract_Zero_From_Positive_Currencies()
        {
            Subtract_Two_Currencies(1, 0);
        }
        
        private static void Sum_Two_Currencies(int amountA, int amountB)
        {
            Currency a = new(amountA);
            Currency b = new(amountB);
            
            var expected = new Currency(amountA + amountB);

            Assert.That(a + b, Is.EqualTo(expected));
        }
        
        private static void Subtract_Two_Currencies(int amountA, int amountB)
        {
            Currency a = new(amountA);
            Currency b = new(amountB);
            
            var expected = new Currency(amountA - amountB);

            Assert.That(a - b, Is.EqualTo(expected));
        }
    }
}
