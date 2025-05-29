namespace ReservationSystem
{
    public class CarRentalReservation : Reservation
    {
        public string CarType { get; set; }
        public string InsuranceOptions { get; set; }

        public CarRentalReservation(string id, string name, DateTime start, DateTime end, string carType, string insurance)
            : base(id, name, start, end)
        {
            CarType = carType;
            InsuranceOptions = insurance;
        }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal dailyRate = CarType switch
            {
                "Economy" => 40,
                "SUV" => 70,
                _ => 50
            };

            decimal insuranceCost = InsuranceOptions == "Full" ? 20 * days : 10 * days;

            return days * dailyRate + insuranceCost;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Car Type: {CarType}, Insurance: {InsuranceOptions}");
        }
    }
}