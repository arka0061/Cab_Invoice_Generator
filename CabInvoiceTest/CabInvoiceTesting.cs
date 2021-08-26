using NUnit.Framework;
using Cab_Invoice_Generator;
namespace CabInvoiceTest
{
    public class Tests
    {
        /// <summary>
        /// UC1 Testing
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForNormalRide_WhenAnalyzeFare_ShouldReturnTrue()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            double distance = 5.0;
            int time = 10;
            double fare = invoice.CalculateFare(distance, time);
            double expected = 60.0;
            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// UC1 Testing
        /// </summary>
           
        [Test]
        public void GivenInvalidTime_WhenAnalyze_ShouldReturnCabInvoiceException()
        {
            string expected = "Time should be positive integer";
            try
            {
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                double distance = 10;
                int time = 0;
                double fare = invoice.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(expected, ex.message);
            }
        }
        /// <summary>
        /// UC2 Testing
        /// </summary>
        [Test]
        public void GivenTotalRides_WhenAnalyze_ShouldReturnTotalFaresOfMultipleRides()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = new InvoiceSummary(2,30);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.totalFare, expected.totalFare);
        }       
    }
}