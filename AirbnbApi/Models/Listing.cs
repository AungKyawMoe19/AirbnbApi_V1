namespace AirbnbApi.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public string Location { get; set; }
    }
}
