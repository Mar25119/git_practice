namespace ReservationSystem
{
    public abstract class Reservation
    {
        public string ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        protected Reservation(string reservationID, string customerName, DateTime startDate, DateTime endDate)
        {
            ReservationID = reservationID;
            CustomerName = customerName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public abstract decimal CalculatePrice();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Reservation ID: {ReservationID}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"From: {StartDate.ToShortDateString()} To: {EndDate.ToShortDateString()}");
        }
    }
}