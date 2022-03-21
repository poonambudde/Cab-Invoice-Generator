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
        RideRepository RideRepository = new RideRepository();
        public double CalculateFair(double distance, int time)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }

        public double CalculateFair(double distance, int time, RideType type)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }
        public void AddRide(string userId, double distance, int time)
        {
            var userRides = RideRepository.GetRideByUserId(userId);
            if (userRides == null)
            {
                var userride = new List<Ride>();
                userride.Add(new Ride()
                {
                    distance = distance,
                    time = time
                });
                RideRepository.AddRideInRideRepo(userId, userride);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time
                });
                RideRepository.AddRideInRideRepo(userId, userRides);
            }
        }
        public void AddRide(RideType rideType, string userId, double distance, int time)
        {
            var userRides = RideRepository.GetRideByUserId(userId);
            if (userRides == null)
            {
                var userride = new List<Ride>();
                userride.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                    type = rideType

                });
                RideRepository.AddRideInRideRepo(userId, userride);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                    type = rideType
                });
                RideRepository.AddRideInRideRepo(userId, userRides);
            }
        }

        public InvoiceSummary CalculateAggregate(String userId)
        {
            var userRides = RideRepository.GetRideByUserId(userId);
            double fair = 0;
            foreach(Ride ride in userRides)
            {
                fair += CalculateFair(ride.distance, ride.time, ride.type);
            }
            var summary = new InvoiceSummary()
            {
                TotalNoOfRides = userRides.Count,
                AvgFair = fair / userRides.Count,
                TotalFair = fair
            };
            return summary;
        }
    }
}
