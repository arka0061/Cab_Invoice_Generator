using System;

namespace Cab_Invoice_Generator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL_RIDE);
            Ride[] rides = { new Ride(2.0, 5), new Ride(6, 10) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Console.WriteLine(summary.totalFare);
        }
    }
}
