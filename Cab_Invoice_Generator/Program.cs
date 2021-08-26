using System;

namespace Cab_Invoice_Generator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL_RIDE);
            Ride[] ride1 = { new Ride(2.0, 5), new Ride(0.1, 1) };
            Ride[] ride2 = { new Ride(3.0, 6), new Ride(4.1, 5) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(1, ride1);
            rideRepository.AddRide(2, ride2);
            var rideArray = rideRepository.GetRides(1);        
        }       
    }
}
