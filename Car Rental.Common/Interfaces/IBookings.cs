using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBookings
{
	public int Id { get; init; }
	public string RegNo { get; init; }
	public string Customer { get; init; }
	public int KmRented { get; init; }
	public double Cost { get; }
	public DateTime DateRented { get; init; }
	public int KmReturned { get; }
	public DateTime? DateReturned { get; }

	public BookingStatus Status { get; }

	public void CloseBooking(int? km);

	public void CalculateCost(int dailyPrice, double kmPrice, int kmRented, int kmReturned);
}

