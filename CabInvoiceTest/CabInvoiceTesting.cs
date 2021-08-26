using NUnit.Framework;
using Cab_Invoice_Generator;
namespace CabInvoiceTest
{
    public class Tests
    {
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
    }
}