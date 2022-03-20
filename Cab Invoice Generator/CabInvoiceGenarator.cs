using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class CabInvoiceGenarator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FAIR = 5;
        List<Ride> rides = new List<Ride>();

        public double CalculateFair(double distance, int time)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }

        public void AddRide(double distance, int time)
        {
            rides.Add(new Ride() { 
            distance = distance,
            time = time
            });
        }

        public InvoiceSummary CalculateAggregate()
        {
            double fair = 0;
            foreach(Ride ride in rides)
            {
                fair += CalculateFair(ride.distance, ride.time);
            }
            var summary = new InvoiceSummary()
            {
                TotalNoOfRides = rides.Count,
                AvgFair = fair / rides.Count,
                TotalFair = fair
            };
            return summary;
        }
    }
}
