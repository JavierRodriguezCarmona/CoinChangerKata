using System;
using System.Collections.Generic;

namespace CoinChangerKata
{
    public class CoinChanger
    {
        public List<int> GetChange(int changeAmount, List<int> coinDenominations)
        {
            if (changeAmount < 0)
            {
                throw new ArgumentException($"Change amount({changeAmount}) should be positive or zero.");
            }

            var changeDictionary = new Dictionary<int, int>();
            var changeList = new List<int>();
            var orderedCoinDenomination = new List<int>(coinDenominations);
            orderedCoinDenomination.Sort();

            for (int i = orderedCoinDenomination.Count - 1; i >= 0; i--)
            {
                changeDictionary.Add(orderedCoinDenomination[i], changeAmount/ orderedCoinDenomination[i]);
                changeAmount -= (changeAmount / orderedCoinDenomination[i])* orderedCoinDenomination[i];
            }

            if (changeAmount > 0)
            {
                throw new ArgumentException("Exact change could not be given.");
            }

            foreach (var coinDenomination in coinDenominations)
            {
                changeList.Add(changeDictionary[coinDenomination]);
            }

            return changeList;
        }
    }
}