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
        /// <summary>
        /// UC3-Returns the average ride
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenAnalyze_ShouldReturnAverageFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(5.0, 6) };

            InvoiceSummary summary = new InvoiceSummary(2, 81.0);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.averageFare, expected.averageFare);
        }
        /// <summary>
        /// UC3-returns the number of rides
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenAnalyze_ShouldReturnNumberOFRides()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = invoice.CalculateFare(rides);
            Assert.AreEqual(summary.numOfRides, expected.numOfRides);
        }
        /// <summary>
        /// UC4-Adding the data in the list correponding userid and rides
        /// </summary>
        [Test]
        public void GivenUserIDs_WhenAnalyze_ShouldReturnFare()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(1, rides);
            rideRepository.AddRide(2, rides);
            var rideArray = rideRepository.GetRides(1);
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            InvoiceSummary summary = new InvoiceSummary(2, 30.0);
            InvoiceSummary expected = invoice.CalculateFare(rideArray);
            Assert.AreEqual(summary.totalFare, expected.totalFare);
        }
    }
}
