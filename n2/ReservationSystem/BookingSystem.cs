using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationSystem
{
    public class BookingSystem
    {
        private List<Reservation> reservations = new List<Reservation>();

        public Reservation CreateReservation(string type, string id, string name, DateTime start, DateTime end, params object[] options)
        {
            Reservation reservation = type.ToLower() switch
            {
                "hotel" => new HotelReservation(id, name, start, end, options[0].ToString(), options[1].ToString()),
                "flight" => new FlightReservation(id, name, start, end, options[0].ToString(), options[1].ToString()),
                "car" => new CarRentalReservation(id, name, start, end, options[0].ToString(), options[1].ToString()),
                _ => throw new ArgumentException("Unknown reservation type")
            };

            reservations.Add(reservation);
            return reservation;
        }

        public bool CancelReservation(string reservationID)
        {
            var res = reservations.FirstOrDefault(r => r.ReservationID == reservationID);
            if (res != null)
            {
                reservations.Remove(res);
                return true;
            }
            return false;
        }

        public decimal GetTotalBookingValue()
        {
            return reservations.Sum(r => r.CalculatePrice());
        }

        public void DisplayAllReservations()
        {
            foreach (var res in reservations)
            {
                res.DisplayDetails();
                Console.WriteLine($"Price: {res.CalculatePrice():C}\n");
            }
        }
    }
}