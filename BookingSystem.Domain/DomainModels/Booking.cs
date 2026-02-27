using BookingSystem.Domain.Enums;

namespace BookingSystem.Domain.DomainModels
{
	public class Booking
	{
		public string BookingCode { get; set; }
		public string OptionCode { get; set; }
		public DateTime BookingTime { get; set; }
		public int SleepTime { get; set; }
		public SearchTypeEnum SearchType { get; set; }
	}
}
