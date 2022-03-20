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

        // given distance in km and time in min should generate fair.
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

        //Invoice Generator should return total number of rides.
        [Test]
        public void AddMultipleRideToCheckTotaltNoOfRide()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(2, invoiceSummary.TotalNoOfRides);
        }
        //Invoice Generator should return total fair.
        [Test]
        public void AddMultipleRideToCheckTotalFair()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, invoiceSummary.TotalFair);
        }
        //Invoice Generator should return average fair.
        [Test]
        public void AddMultipleRideToCheckAvgFair()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(80, invoiceSummary.AvgFair);
        }
    }
}