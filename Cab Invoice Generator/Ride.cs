using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Ride
    {
        public double distance { get; set; }
        public int time { get; set; }
        public RideType type { get; set; }
    }
}
