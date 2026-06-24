using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Passenger
    {
        public int passengerId { get; set; } // generated
        public string passengerName { get; set; } // input
        public string passengerEmail { get; set; } // input
        public string passengerPhone { get; set; } // input
        public string passportNumber { get; set; } // input
        public string nationality { get; set; }  // input
    }
}
