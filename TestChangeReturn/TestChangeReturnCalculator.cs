using ChangeReturn;
using NUnit.Framework;

namespace TestChangeReturn
{
    public class TestChangeReturnCalculator
    {
        private ChangeReturnCalculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new ChangeReturnCalculator();
        }

        [Test]
        public void checkCalculatorForHighValue()
        {
            calc.setCostAndPaid(355,746.2m);
            var result = calc.calculateCoinReturns();
            Assert.AreEqual(result[100], 3);
            Assert.AreEqual(result[50], 1);
            Assert.AreEqual(result[20], 2);
            Assert.AreEqual(result[10], 0);
            Assert.AreEqual(result[5], 0);
            Assert.AreEqual(result[0.50m], 2);
            Assert.AreEqual(result[0.20m], 1);
            Assert.AreEqual(result[0.10m], 0);
            Assert.AreEqual(result[0.05m], 0);
            Assert.AreEqual(result[0.02m], 0);
            Assert.AreEqual(result[0.01m], 0);
        }
        [Test]
        public void checkCalculatorForSmallValue()
        {
            calc.setCostAndPaid(1.5m, 2.99m);
            var result = calc.calculateCoinReturns();
            Assert.AreEqual(result[100], 0);
            Assert.AreEqual(result[50], 0);
            Assert.AreEqual(result[20], 0);
            Assert.AreEqual(result[10], 0);
            Assert.AreEqual(result[5], 0);
            Assert.AreEqual(result[0.50m], 2);
            Assert.AreEqual(result[0.20m], 2);
            Assert.AreEqual(result[0.10m], 0);
            Assert.AreEqual(result[0.05m], 1);
            Assert.AreEqual(result[0.02m], 2);
            Assert.AreEqual(result[0.01m], 0);
        }
    }
}