using Flight_Management_System.Models;
using System.Net.WebSockets;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        // case 2 >> Add  Aircraft
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
                isOperational=true
            });

            Console.WriteLine($"Aircraft Added sucessfuly with ID :{Aircraftid}");
        }

        //-----------------------------
        // case 3 >> Register a Pilot
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

        //-----------------------------
        // case 4 >> View All Flights
        //-----------------------------
        public static void ViewAllFlights()
        {
            int flightcode = Context.Flights.Count + 1;
            string code = "OA- " + flightcode;

            Console.WriteLine("Enter flight origin: ");
            string flightOrigin = Console.ReadLine();

            Console.WriteLine("Enter flight destination: ");
            string flightdestination = Console.ReadLine();

            Console.WriteLine("Enter departure Date: ");
            string departuredate = Console.ReadLine();

            Console.WriteLine("Enter departure Time: ");
            string departuretime = Console.ReadLine();

            Console.WriteLine("Enter ticket Price: ");
            decimal ticketprice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter available Seats: ");
            int availableSeat = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter flight Duration: ");
            decimal duration = decimal.Parse(Console.ReadLine());

            int flightid = Context.Flights.Count + 1;

            Console.WriteLine("Enter aircraft Id");
            int aircraftid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter pilot Id");
            int pilotid = int.Parse(Console.ReadLine());

            //Aircraft aircrafttid = Context.Aircrafts.FirstOrDefault(item => item.aircraftId == aircraftid);
            //Pilot pilottid = Context.Pilots.FirstOrDefault(item => item.pilotId == pilotid);


            Context.Flights.Add(new Flight
            {
                flightId = flightid,
                flightCode= code,
                origin = flightOrigin,
                //aircraftId=aircrafttid.aircraftId,
                //pilotId = pilottid.pilotId,
                destination = flightdestination,
                departureDate = departuredate,
                departureTime = departuretime,
                ticketPrice = ticketprice,
                availableSeats = availableSeat,
                flightDuration = duration,
                status = "Scheduled"
            });

            foreach (Flight flight in Context.Flights)
            {


                Console.WriteLine("_____**************______ ");
                Console.WriteLine("      Flight Details       ");
                Console.WriteLine("_____**************______ ");

                Console.WriteLine($"\n Flight Code : {flight.flightCode} " +
                    $"\n Flight Origin : {flight.origin}" +
                    $"\n Destination : {flight.destination}" +
                    $"\n Departure Date : {flight.departureDate}" +
                    $"\n Departure Time : {flight.departureTime}" +
                    $"\n Available Seats : {flight.availableSeats}" +
                    $"\n Ticket Price : {flight.ticketPrice}" +
                    $"\n status : {flight.status}");

            }
        }


        //-----------------------------
        // case 5 >> Schedule a Flight
        //-----------------------------
        public static void SchedulenewFlight()
        {
            Console.WriteLine("-----************-------");
            Console.WriteLine(" schedules a new flight ");
            Console.WriteLine("-----************-------");

            // view all aircraft
            foreach (Aircraft aircraft in Context.Aircrafts)
            {
                Console.WriteLine("#### Available Aircraft ####");
                Console.WriteLine($"\n aircraft Id : {aircraft.aircraftId}" +
                    $"\n total Seats: {aircraft.totalSeats}" +
                    $"\n is Operational:{aircraft.isOperational}  ");

            }
            //select one
            Console.WriteLine("choose Aircraft ID: ");
            int Aircraftid = int.Parse(Console.ReadLine());

            //check user input
            Aircraft selectedAircraftid = Context.Aircrafts.FirstOrDefault(item => item.aircraftId == Aircraftid && item.isOperational==true);

            //check not null
            if(selectedAircraftid == null)
            {
                Console.WriteLine(" This Aircraft Not Available ");
                return;
            }

            //View and assign a pilot
            foreach(Pilot p in Context.Pilots)
            {
                Console.WriteLine("#### Available Pilot ####");
                Console.WriteLine($"\n pilot Id :{p.pilotId}" +
                    $"\n pilot Name: {p.pilotName}" +
                    $"\n is Available: {p.isAvailable}");
            }
         

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
                    ViewAllFlights();
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
