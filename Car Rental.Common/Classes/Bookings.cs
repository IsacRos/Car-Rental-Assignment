using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Bookings : IBookings
{
	public int Id { get; init; }
	public string RegNo { get; init; }
	public string Customer { get; init; }
	public int KmRented { get; init; }
	public double Cost { get; set; }
	public DateTime DateRented { get; init; }
	public int KmReturned { get; private set; }
	public DateTime? DateReturned { get; private set; }

	public BookingStatus Status { get; private set; }

    public Bookings(string regno, string customer, int kmrented, DateTime daterented)
    {
        RegNo = regno;
		Customer = customer;
		KmRented = kmrented;
		DateRented = daterented;
    }

	public void CloseBooking(int? km)
	{
		DateReturned = DateTime.Now;
		Status = BookingStatus.Closed;
		KmReturned += KmRented + (km ?? 0);
	}

    public void CalculateCost(int dailyPrice, double kmPrice, int kmRented, int kmReturned) => Cost =
    (dailyPrice + (kmPrice * (kmReturned - kmRented)));

}
