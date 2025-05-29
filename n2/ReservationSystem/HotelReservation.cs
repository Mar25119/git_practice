namespace ReservationSystem
{
    public class HotelReservation : Reservation
    {
        public string RoomType { get; set; }
        public string MealPlan { get; set; }

        public HotelReservation(string id, string name, DateTime start, DateTime end, string room, string meal)
            : base(id, name, start, end)
        {
            RoomType = room;
            MealPlan = meal;
        }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal pricePerDay = RoomType switch
            {
                "Standard" => 100,
                "Deluxe" => 150,
                _ => 200
            };

            decimal mealPrice = MealPlan switch
            {
                "Breakfast" => 20,
                "FullBoard" => 50,
                _ => 0
            };

            return days * (pricePerDay + mealPrice);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Room Type: {RoomType}, Meal Plan: {MealPlan}");
        }
    }
}