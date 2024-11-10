namespace AirbnbApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key for User
        public int ListingId { get; set; } // Foreign key for Listing
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Confirmed"
    }
}
