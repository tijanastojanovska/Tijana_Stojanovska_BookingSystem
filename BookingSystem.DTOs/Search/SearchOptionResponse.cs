namespace BookingSystem.DTOs.Search
{
	public class SearchOptionResponse
	{
		public string OptionCode { get; set; }
		public string HotelCode { get; set; }
		public string? FlightCode { get; set; }
		public string ArrivalAirport { get; set; }
		public double Price { get; set; }
	}
}
