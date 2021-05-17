using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;

namespace ChangeReturn
{
    class Program
    {
        /// <summary>
        /// 1,5 h
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            try
            {
                parseArgs(args,  out decimal paid, out decimal cost);
                if (cost > paid)
                {
                    Console.WriteLine("Es wurde zu wenig bezahlt.");
                }
                else
                {
                    ChangeReturnCalculator calc = new ChangeReturnCalculator(cost, paid);
                    Dictionary<decimal, int> returnDict = calc.calculateCoinReturns();
                    createOutput(returnDict, cost, paid);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Die Eingabeparameter hatten das falsche Format");
            }
        }

        private static void createOutput(Dictionary<decimal, int> keyValuePairs, decimal cost, decimal paid)
        {
            Console.WriteLine($"Cost: {cost}");
            Console.WriteLine($"Paid: {paid}");
            Console.WriteLine($"Return: {paid - cost}");
            foreach (KeyValuePair<decimal, int> keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Value > 0)
                {
                    Console.WriteLine($"Coin: {keyValuePair.Key}; Amount: {keyValuePair.Value}");
                }
            }
            Console.ReadLine();
        }

        public static void parseArgs(string[] args, out decimal paid, out decimal cost)
        {
            paid = 0;
            cost = 0;
            if (args.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (args[i].ToLower() == "-totalcost")
                    {
                        cost = Decimal.Parse(args[i + 1]);
                    }
                    if (args[i].ToLower() == "-totalpaid")
                    {
                        paid = Decimal.Parse(args[i + 1]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Not enought Options given");
            }
        }
    }
}
