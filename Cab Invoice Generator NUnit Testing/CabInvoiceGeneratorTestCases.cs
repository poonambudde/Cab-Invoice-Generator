using Cab_Invoice_Generator;
using NUnit.Framework;

namespace Cab_Invoice_Generator_NUnit_Testing
{
    public class Tests
    {
        public CabInvoiceGenarator cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenarator();
        }

        // Step1- given distance in km and time in min should generate fair.
        [Test]
        public void Test1()
        {
            double fair = cabInvoiceGenerator.CalculateFair(2,5);
            Assert.AreEqual(25,fair);
        }
        [Test]
        public void CheckMinimumFairAsFive()
        {
            double fair = cabInvoiceGenerator.CalculateFair(0,0);
            Assert.AreEqual(5, fair);
        }

        // step2- for multiple ride generate aggregate fair
        [Test]
        public void CalAggFairAndMultipleRide()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            double fair = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, fair);
        }
    }
}