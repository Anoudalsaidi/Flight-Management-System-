using Flight_Management_System.Models;

namespace Flight_Management_System
{
    public class Program
    {
        // System Storge
        public static FlightContext Context = new FlightContext
        {
            Aircrafts = new List<Models.Aircraft>(),
            Bookings = new List<Models.Booking>(),
            Flights = new List<Models.Flight>(),
            passengers=new List<Models.Passenger>(),
            Pilots=new List<Models.Pilot>(),
        };
        //-----------------------------
        // case 1 > Register Passenger
        //-----------------------------
        public static void RegisterPassenger()
        {
            Console.WriteLine(" Enter passenger Full Name:");
            string passengername = Console.ReadLine();

            Console.WriteLine(" Enter passenger Email:");
            string passengeremail = Console.ReadLine();

            Console.WriteLine(" Enter passenger Phone:");
            string passengerphone = Console.ReadLine();

            Console.WriteLine(" Enter passport Number:");
            string passportnumber = Console.ReadLine();

            Console.WriteLine(" Enter nationality:");
            string Nationality = Console.ReadLine();

            int passengerid = Context.passengers.Count + 1;

            Context.passengers.Add(new Passenger
            {
                passengerId=passengerid,
                passengerName=passengername,
                passengerEmail=passengeremail,
                passengerPhone=passengerphone,
                passportNumber=passportnumber,
                nationality=Nationality
            });

            Console.WriteLine($"passenger has been Addedd successfuly with ID : {passengerid}");
        }

        //-----------------------------
        // case 2 > Add  Aircraft
        //-----------------------------
        public static void AddAircraft()
        {
            Console.WriteLine("Enter Aircraft model:");
            string AircraftModel = Console.ReadLine();

            Console.WriteLine("Enter total Seats:");
            int TotalSeat =int.Parse( Console.ReadLine());

            int Aircraftid = Context.Aircrafts.Count + 1;

            Context.Aircrafts.Add(new Aircraft
            {
                aircraftId=Aircraftid,
                model=AircraftModel,
                totalSeats=TotalSeat,
                isOperational=false
            });

            Console.WriteLine($"Aircraft Added sucessfuly with ID :{Aircraftid}");
        }

        //-----------------------------
        // case 3 >Register a Pilot
        //-----------------------------
        public static void RegisterPilot()
        {

            Console.WriteLine("Enter pilot Name: ");
            string pilotaame = Console.ReadLine();

            Console.WriteLine("Enter pilot Phone: ");
            string pilotphone = Console.ReadLine();

            Console.WriteLine("Enter license Number: ");
            string licensenumber = Console.ReadLine();

            Console.WriteLine("Enter flight Hours: ");
            int flightHour =int.Parse( Console.ReadLine());

            int pilotid = Context.Pilots.Count + 1;

            Context.Pilots.Add(new Pilot
            {
                pilotId=pilotid,
                pilotName=pilotaame,
                pilotPhone=pilotphone,
                licenseNumber=licensenumber,
                flightHours= flightHour,
                isAvailable=false

            });
            Console.WriteLine($"Pilot has been added with ID: {pilotid}");
        }



























        static void Main(string[] args)
        {

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("^^^^^^^-------------------^^^^^^^^");
                Console.WriteLine("Welcome To Flight Management System ");
                Console.WriteLine("^^^^^^^-------------------^^^^^^^^");
                Console.WriteLine("\nselect an Option:");
                Console.WriteLine("1- Register a Passenger ");
                Console.WriteLine("2- Add an Aircraft ");
                Console.WriteLine("3- Register a Pilot ");
                Console.WriteLine("4- View All Flights ");
                Console.WriteLine("5- Schedule a Flight ");
                Console.WriteLine("6- Book a Flight ");
                Console.WriteLine("7- Cancel a Booking ");
                Console.WriteLine("8- Depart a Flight ");
                Console.WriteLine("9- Cancel a Flight ");
                Console.WriteLine("10- Passenger Booking History ");
                Console.WriteLine("11- Flight Revenue & Load Factor Report ");
                Console.WriteLine("0- Exsit ");
            }

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    RegisterPassenger();
                    break;
                case 2:
                    AddAircraft();
                    break;
                case 3:
                    RegisterPilot();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n Invalid Input, Try Again");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine("\n Press any key to continue ..");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
