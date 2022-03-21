using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class RideType
    {
        public int COST_PER_KM = 0;
        public int COST_PER_MINUTE = 0;
        public int MINIMUM_FAIR = 0;

        public RideType Normal = new RideType()
        {
            COST_PER_KM = 10,
            COST_PER_MINUTE = 1,
            MINIMUM_FAIR = 5
        };

        public RideType Premium = new RideType()
        {
            COST_PER_KM = 15,
            COST_PER_MINUTE = 2,
            MINIMUM_FAIR = 20
        };
    }
}
