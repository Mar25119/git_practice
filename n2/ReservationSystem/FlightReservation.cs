namespace ReservationSystem
{
    public class FlightReservation : Reservation
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        public FlightReservation(string id, string name, DateTime start, DateTime end, string departure, string arrival)
            : base(id, name, start, end)
        {
            DepartureAirport = departure;
            ArrivalAirport = arrival;
        }

        public override decimal CalculatePrice()
        {
            return 300m;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"From: {DepartureAirport} To: {ArrivalAirport}");
        }
    }
}