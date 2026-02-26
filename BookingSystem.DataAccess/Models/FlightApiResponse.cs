using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.DataAccess.Models
{
	public class FlightApiResponse
	{
		public int FlightCode { get; set; }
		public string FlightNumber { get; set; }
		public string DepartureAirport { get; set; }
		public string ArrivalAirport { get; set; }
	}
}
