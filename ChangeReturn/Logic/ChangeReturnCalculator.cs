using System;
using System.Collections.Generic;

namespace ChangeReturn
{
    public class ChangeReturnCalculator
    {
        private decimal totalCost { get; set; }
        private decimal totalPaid { get; set; }

        private decimal[] validChange = { 100, 50, 20, 10, 5, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

        /// <summary>
        /// Class to calculate the Coins, which should be given back.
        /// </summary>
        public ChangeReturnCalculator()
        {

        }
        public ChangeReturnCalculator(decimal totalCost, decimal totalPaid)
        {
            this.totalCost = totalCost;
            this.totalPaid = totalPaid;
        }
        /// <summary>
        /// Calculates the Return Money
        /// </summary>
        /// <returns>Returns the Change as Decimal</returns>
        public decimal calculateReturn()
        {
            return this.totalPaid - this.totalCost;
        }
        /// <summary>
        /// Sets the Cost and Paid Parameters
        /// </summary>
        /// <param name="totalCost">The Total Cost</param>
        /// <param name="totalPaid">The Total Paid</param>
        public void setCostAndPaid(decimal totalCost, decimal totalPaid)
        {
            this.totalCost = totalCost;
            this.totalPaid = totalPaid;
        }
        /// <summary>
        /// Calculates the different Coins, which has to be returned
        /// </summary>
        /// <returns>An Dictionary with the Coin Value as Decimal and the Amount of Coins</returns>
        public Dictionary<decimal, int> calculateCoinReturns()
        {
            Dictionary<decimal, int> returnDict = new Dictionary<decimal, int>();

            decimal changeMoney = calculateReturn();
            foreach (decimal coin in validChange)
            {
                // Calculate, wether coinvalue can be given back or not
                var coinnumber = calculateCoinNumbers(changeMoney, coin);
                returnDict.Add(coin, coinnumber);
                // Substract the number of Coins from the ChangeMoney
                changeMoney = changeMoney - (coinnumber * coin);
            }

            return returnDict;
        }
        /// <summary>
        /// Calculastes the Number of Coins for the CoinType
        /// </summary>
        /// <param name="change">The Amount of Change Left</param>
        /// <param name="cointype">The CoinType</param>
        /// <returns>The Amount of Coins from the given Type</returns>
        private int calculateCoinNumbers(decimal change, decimal cointype)
        {
            return (int) Math.Floor(change / cointype);
        }

    }
}
