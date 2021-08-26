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
    }
}
