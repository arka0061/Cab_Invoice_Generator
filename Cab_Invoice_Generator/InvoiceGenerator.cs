using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {     
        RideType type;
        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;
        public InvoiceGenerator(RideType type)
        {
            this.type = type;
            if (type.Equals(RideType.NORMAL_RIDE))
            {
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 5;
            }
            if (this.type.Equals(RideType.PREMIUM_RIDE))

            {
                this.MINIMUM_COST_PER_KM = 15;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 20;

            }
        }
        public double CalculateFare(double distance, int time)

        {
            double totalFare = 0.0;
            try
            {
                if (!(distance <= 0 && time <= 0))
                {
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                }

                else if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Distance should be positive integer");
                }
                else if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Time should be positive integer");
                }
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.message);
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No rides found");
                }
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.message);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        public void AddRides(int userID,Ride[] rides)
        {
            RideRepository rideRepository = new RideRepository();
            try
            {
               rideRepository.AddRide(userID, rides);
            }
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
        }
        public InvoiceSummary GetInvoiceSummary(int userId)
        {
            RideRepository rideRepository = new RideRepository();
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserId");
            }
        }
    }
}
