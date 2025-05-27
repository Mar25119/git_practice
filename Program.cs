using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem
{
    public abstract class Reservation
    {
        public string ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public abstract decimal CalculatePrice();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Reservation ID: {ReservationID}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Start Date: {StartDate.ToShortDateString()}");
            Console.WriteLine($"End Date: {EndDate.ToShortDateString()}");
        }
    }

    public class HotelReservation : Reservation
    {
        public string RoomType { get; set; }
        public string MealPlan { get; set; }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal basePrice = 100 * days;
            decimal mealPrice = MealPlan == "Full" ? 50 * days : 20 * days;
            return basePrice + mealPrice;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Room Type: {RoomType}");
            Console.WriteLine($"Meal Plan: {MealPlan}");
            Console.WriteLine($"Total Price: {CalculatePrice():C}");
        }
    }

    public class FlightReservation : Reservation
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        public override decimal CalculatePrice()
        {
            return 200; 
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Departure Airport: {DepartureAirport}");
            Console.WriteLine($"Arrival Airport: {ArrivalAirport}");
            Console.WriteLine($"Total Price: {CalculatePrice():C}");
        }
    }

    public class CarRentalReservation : Reservation
    {
        public string CarType { get; set; }
        public bool InsuranceOptions { get; set; }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal basePrice = 40 * days;
            if (InsuranceOptions) basePrice += 20 * days;
            return basePrice;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Car Type: {CarType}");
            Console.WriteLine($"Insurance Included: {InsuranceOptions}");
            Console.WriteLine($"Total Price: {CalculatePrice():C}");
        }
    }

    public class BookingSystem
    {
        private List<Reservation> _reservations = new List<Reservation>();

        public Reservation CreateReservation(string reservationType)
        {
            Reservation reservation = null;

            switch (reservationType.ToLower())
            {
                case "hotel":
                    reservation = new HotelReservation
                    {
                        ReservationID = Guid.NewGuid().ToString(),
                        CustomerName = "John Doe",
                        StartDate = DateTime.Now.AddDays(1),
                        EndDate = DateTime.Now.AddDays(4),
                        RoomType = "Deluxe",
                        MealPlan = "Full"
                    };
                    break;

                case "flight":
                    reservation = new FlightReservation
                    {
                        ReservationID = Guid.NewGuid().ToString(),
                        CustomerName = "Jane Smith",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1),
                        DepartureAirport = "JFK",
                        ArrivalAirport = "LAX"
                    };
                    break;

                case "car":
                    reservation = new CarRentalReservation
                    {
                        ReservationID = Guid.NewGuid().ToString(),
                        CustomerName = "Mike Johnson",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(3),
                        CarType = "SUV",
                        InsuranceOptions = true
                    };
                    break;

                default:
                    Console.WriteLine("Unknown reservation type");
                    break;
            }

            if (reservation != null)
            {
                _reservations.Add(reservation);
                reservation.DisplayDetails();
            }

            return reservation;
        }

        public void CancelReservation(string reservationID)
        {
            var res = _reservations.FirstOrDefault(r => r.ReservationID == reservationID);
            if (res != null)
            {
                _reservations.Remove(res);
                Console.WriteLine($"Reservation {reservationID} canceled.");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
        }

        public decimal GetTotalBookingValue()
        {
            return _reservations.Sum(r => r.CalculatePrice());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bookingSystem = new BookingSystem();

            bookingSystem.CreateReservation("hotel");
            bookingSystem.CreateReservation("flight");
            bookingSystem.CreateReservation("car");

            Console.WriteLine($"\nTotal Booking Value: {bookingSystem.GetTotalBookingValue():C}");

            bookingSystem.CancelReservation("some-id-here"); 
        }
    }
}
