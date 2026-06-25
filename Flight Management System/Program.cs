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
            //int flightcode = Context.Flights.Count + 1;
            //string code = "OA- " + flightcode;

            //Console.WriteLine("Enter flight origin: ");
            //string flightOrigin = Console.ReadLine();

            //Console.WriteLine("Enter flight destination: ");
            //string flightdestination = Console.ReadLine();

            //Console.WriteLine("Enter departure Date: ");
            //string departuredate = Console.ReadLine();

            //Console.WriteLine("Enter departure Time: ");
            //string departuretime = Console.ReadLine();

            //Console.WriteLine("Enter ticket Price: ");
            //decimal ticketprice = decimal.Parse(Console.ReadLine());

            //Console.WriteLine("Enter available Seats: ");
            //int availableSeat = int.Parse(Console.ReadLine());


            //Console.WriteLine("Enter flight Duration: ");
            //decimal duration = decimal.Parse(Console.ReadLine());

            //int flightid = Context.Flights.Count + 1;

            //Console.WriteLine("Enter aircraft Id");
            //int aircraftid = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter pilot Id");
            //int pilotid = int.Parse(Console.ReadLine());

            ////Aircraft aircrafttid = Context.Aircrafts.FirstOrDefault(item => item.aircraftId == aircraftid);
            ////Pilot pilottid = Context.Pilots.FirstOrDefault(item => item.pilotId == pilotid);


            //Context.Flights.Add(new Flight
            //{
            //    flightId = flightid,
            //    flightCode= code,
            //    origin = flightOrigin,
            //    //aircraftId=aircrafttid.aircraftId,
            //    //pilotId = pilottid.pilotId,
            //    destination = flightdestination,
            //    departureDate = departuredate,
            //    departureTime = departuretime,
            //    ticketPrice = ticketprice,
            //    availableSeats = availableSeat,
            //    flightDuration = duration,
            //    status = "Scheduled"
            //});

            foreach (Flight flight in Context.Flights)
            {


                Console.WriteLine("_____**************______ ");
                Console.WriteLine("      Flight Details       ");
                Console.WriteLine("_____**************______ ");

                Console.WriteLine($"\n Flight Id: {flight.aircraftId}" +
                    $"\n Flight Code : {flight.flightCode} " +
                    $"\n aircraft Id : {flight.flightId}" +
                    $"\n pilot Id : {flight.pilotId}" +
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

            //Generate ID
            int flightid = Context.Flights.Count + 1;

            // Generate code
            int flightcode = Context.Flights.Count + 1;
            string code = "OA- " + flightcode;
          

            //-----------------------------------------------
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

            //------------------------------------------------------
            //View assign a pilot
            foreach(Pilot p in Context.Pilots)
            {
                Console.WriteLine("#### Available Pilot ####");
                Console.WriteLine($"\n pilot Id :{p.pilotId}" +
                    $"\n pilot Name: {p.pilotName}" +
                    $"\n is Available: {p.isAvailable}");
            }

            // select one 
            Console.WriteLine("Enter Selected Pilot ID :");
            int pilotid = int.Parse(Console.ReadLine());

            //check input
            Pilot selectedpilotId = Context.Pilots.FirstOrDefault(item => item.pilotId == pilotid && item.isAvailable == true);
            
            //check id not null
            if(selectedpilotId == null)
            {
                Console.WriteLine("Not pilot match with seleceted ID");
                return;
            }


            //------------------------------------------------
            // user input
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

            Console.WriteLine("Enter flight Duration: ");
            decimal duration = decimal.Parse(Console.ReadLine());




            //assign a pilot
            Context.Flights.Add(new Flight
            {
                flightId= flightid,
                flightCode =code,
               aircraftId= selectedAircraftid.aircraftId,
                pilotId = selectedpilotId.pilotId,
                origin = flightOrigin,
                destination= flightdestination,
                departureDate= departuredate,
                departureTime=departuretime,
                ticketPrice=ticketprice,
                flightDuration=duration,
                availableSeats = selectedAircraftid.totalSeats,
                status = "Scheduled "


            });

            // confirm msg
            Console.WriteLine($"Flight scheduled successfully .. With ID : {flightid}");
           
            // make pilot unavailable
            selectedpilotId.isAvailable = false;
            ViewAllFlights();
          
        }


        //-----------------------------
        // case 6 >> Book a Flight
        //-----------------------------
        public static void BookFlight()
        {
            // user ID
            Console.WriteLine("Enter passenger ID :");
            int passengerid = int.Parse(Console.ReadLine());

            //check input
           Passenger checkid = Context.passengers.FirstOrDefault(p => p.passengerId == passengerid);

         //check null
         if(checkid == null)
            {
                Console.WriteLine("Invlid passenger ID");
                return;
            }

            // view DESTINATION
             ViewAllFlights();
            

            //select destination
            Console.WriteLine("Enter YOUR Destination ");
            string destination = Console.ReadLine();

            //check input
            List<Flight> selectdestination = Context.Flights.Where(f => f.destination == destination && f.status == "Scheduled" && f.availableSeats >0).ToList();

            if(selectdestination.Count == 0)
            {
                Console.WriteLine("Your Destination not available");
                return;
            }

            //view flight id
            foreach (Flight flight in selectdestination)
            {
                Console.WriteLine(
                    $"Flight ID: {flight.flightId}" +
                    $"\nFlight Code: {flight.flightCode}" +
                    $"\nDestination: {flight.destination}" +
                    $"\nAvailable Seats: {flight.availableSeats}" +
                    $"\nPrice: {flight.ticketPrice}");
            }

            //select flight id 
            Console.WriteLine("Select Flight ID :");
            int flightid = int.Parse(Console.ReadLine());

            //check id and avaiable seats
            Flight selectflightid = Context.Flights.FirstOrDefault(f => f.flightId == flightid && f.availableSeats > 0);

            //check null
            if(selectflightid == null)
            {
                Console.WriteLine("No Flight");
                return;
            }


            //generate booking id
            int bookingid = Context.Bookings.Count + 1;

            //geneate seat number
            int seatnum = Context.Bookings.Count + 10;
            string seatnumber = "A-" + seatnum;

            //user input (flight date)
            Console.WriteLine("Enter Booking Date :");
            string bookdate = Console.ReadLine();

            //pick flight
            Context.Bookings.Add(new Booking
            {
                bookingId=bookingid,
                passengerId=passengerid,
                flightId=flightid,
                seatNumber=seatnumber,
                bookingDate=bookdate,
                totalPrice= selectflightid.ticketPrice,
                status= "Confirmed"

            });
            selectflightid.availableSeats --;

            Console.WriteLine($"Booking Added successfully with ID:{bookingid}");
        }


        //-----------------------------
        // case 7 >> Cancel a Booking
        //-----------------------------
        public static void CancelBooking()
        {
            Console.WriteLine("Enter Booking ID you to cancel ");
            int bookingid = int.Parse(Console.ReadLine());

            //check id
            Booking cancelbooking = Context.Bookings.FirstOrDefault(item => item.bookingId == bookingid);

            //check null
            if(cancelbooking == null)
            {
                Console.WriteLine("No Booking available");
                return;
            }

            Flight returnflight = Context.Flights.FirstOrDefault(item => item.flightId == cancelbooking.flightId);
            returnflight.availableSeats++;

            cancelbooking.status= "Cancelled";

            Console.WriteLine($"Booking ID: {cancelbooking.bookingId} has been cancelled successfully");


        }


        //-----------------------------
        // case 8 >> Depart a Flight
        //-----------------------------
        public static void DepartFlight()
        {
            Console.WriteLine("Enter flight ID :");
            int flightid = int.Parse(Console.ReadLine());

            //check flight id
            Flight selectedflightid = Context.Flights.FirstOrDefault(item => item.flightId == flightid);
            
            //check null
            if(selectedflightid == null)
            {
                Console.WriteLine("No flight avialable");
                return;
            }
            
            //check & change satus
            if(selectedflightid.status == "Scheduled")
            {
                selectedflightid.status = "Departed";
                Console.WriteLine($"Flight ID :{selectedflightid.aircraftId} , status has been change to {selectedflightid.status}");
            }

            //check if flight status (Departed ) not allowed to cancel
            if(selectedflightid.status == "Departed")
            {
                Console.WriteLine($"Flight ID : {selectedflightid.flightId}, Status changed to {selectedflightid.status}");
            }
            

            //add hours to pilot
            Pilot selectedpilotid = Context.Pilots.FirstOrDefault(item => item.pilotId == selectedflightid.pilotId);

           

            //check null
            if(selectedpilotid == null)
            {
                Console.WriteLine("No pilot avialable");
                return;
            }
            //selectedpilotid.flightHours += selectedflightid.flightDuration;

            //confirm msg
            Console.WriteLine( $"Flight {selectedflightid.flightCode} departed successfully.");
        }


        //-----------------------------
        // case 9 >> Cancel a Flight
        //-----------------------------
        public static void CancelFlight()
        {
            Console.WriteLine("Flight Details :");
            ViewAllFlights();

            Console.WriteLine("Enter selected Flight ID :");
            int flightid = int.Parse(Console.ReadLine());

            //check input
            Flight selectedflightid = Context.Flights.FirstOrDefault(f => f.flightId == flightid && f.status =="Scheduled ");

            if(selectedflightid == null)
            {
                Console.WriteLine(" flight Not Available");
                return;

            }

            selectedflightid.status = "cancelled";

            //booking belong to that flight id
            List<Booking> bookings = Context.Bookings.Where(b => b.flightId == selectedflightid.flightId && b.status== "Confirmed ").ToList();

            if(bookings.Count == 0)
            {
                Console.WriteLine("No Booking belong this Flight");
                return;
            }

            //view all booking in selected list
            foreach(Booking book in bookings)
            {
                book.status = "cancelled";
            }

            //tel to passinger 
            List<Booking> bookpassing = Context.Bookings.Where(p => p.passengerId == selectedflightid.flightId).ToList();

            if(bookpassing == null)
            {
                Console.WriteLine("No booking in this flight");
                return;
            }

            //view list booking with passinger
            foreach(Booking b in bookpassing)
            {
                Console.WriteLine($" flight id:{selectedflightid.flightId} was cancelled ");
            }

            //tell to pilot
          Pilot pilot = Context.Pilots.FirstOrDefault(p => p.pilotId == selectedflightid.pilotId);
            
            //check input
            if(pilot == null)
            {
                Console.WriteLine("no pilot reisgtered to this flight");
                return;
            }
            //change pilot satus
            pilot.isAvailable = true;

            // effect booking
            int effectbooking = bookings.Count;
            Console.WriteLine($"Flight cancelled successfully. Affected bookings:{effectbooking}");

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
                Console.WriteLine("4- Schedule a Flight ");
                Console.WriteLine("5- View All Flights ");
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
                    SchedulenewFlight();
                    break;
                case 5:
                    ViewAllFlights();
                    break;
                case 6:
                    BookFlight();
                    break;
                case 7:
                    CancelBooking();
                    break;
                case 8:
                    DepartFlight();
                    break;
                case 9:
                    CancelFlight();
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
