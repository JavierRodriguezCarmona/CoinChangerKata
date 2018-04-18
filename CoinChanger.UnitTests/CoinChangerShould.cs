using System;
using System.Collections.Generic;
using NUnit.Framework;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace CoinChangerKata.UnitTests
{
    [TestFixture]
    public class CoinChangerShould
    {
        private CoinChanger _coinChanger;

        [SetUp]
        public void SetUp()
        {
            _coinChanger = new CoinChanger();
        }

        [Test]
        public void ReturnArrayFilledWithZerosIfChangeAmountIsZero()
        {
            List<int> coinDenomination = new List<int> {1, 5, 10, 25, 100};

            List<int> result = _coinChanger.GetChange(0, coinDenomination);

            List<int> expected = new List<int> {0, 0, 0, 0, 0};
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(1, new[] { 1, 0, 0, 0, 0 })]
        [TestCase(5, new[] { 0, 1, 0, 0, 0 })]
        [TestCase(10, new[] { 0, 0, 1, 0, 0 })]
        [TestCase(25, new[] { 0, 0, 0, 1, 0 })]
        [TestCase(100, new[] { 0, 0, 0, 0, 1 })]
        [TestCase(3, new[] { 3, 0, 0, 0, 0 })]
        [TestCase(33, new[] { 3, 1, 0, 1, 0 })]
        public void ReturnExactExchangeForAmountGreaterThanZero(int changeAmount, int[] expected)
        {
            List<int> coinDenomination = new List<int> {1, 5, 10, 25, 100};

            List<int> result = _coinChanger.GetChange(changeAmount, coinDenomination);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(1, new[] { 0, 0, 1, 0, 0 })]
        [TestCase(5, new[] { 0, 1, 0, 0, 0 })]
        [TestCase(10, new[] { 0, 0, 0, 0, 1 })]
        [TestCase(25, new[] { 0, 0, 0, 1, 0 })]
        [TestCase(100, new[] { 1, 0, 0, 0, 0 })]
        [TestCase(3, new[] { 0, 0, 3, 0, 0 })]
        [TestCase(33, new[] { 0, 1, 3, 1, 0 })]
        public void ReturnExactExchangeForAmountGreaterThanZeroAndNotSortedCoinDenomination(int changeAmount, int[] expected)
        {
            List<int> coinDenomination = new List<int> { 100, 5, 1, 25, 10 };

            List<int> result = _coinChanger.GetChange(changeAmount, coinDenomination);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void ThrowWhenChangeAmountIsNegative()
        {
            List<int> coinDenomination = new List<int> { 1, 5, 10, 25, 100 };

            Assert.Throws<ArgumentException>(() => _coinChanger.GetChange(-10, coinDenomination));
        }

        [Test]
        public void ThrowWhenExactChangeCouldNotBeGiven()
        {
            List<int> coinDenomination = new List<int> { 5, 10, 25, 100 };

            Assert.Throws<ArgumentException>(() => _coinChanger.GetChange(3, coinDenomination));
        }
    }
}
