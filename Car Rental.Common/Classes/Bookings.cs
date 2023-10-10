using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Bookings : IBookings
{
	public int Id { get; init; }
	public IVehicle Vehicle { get; init; }
	public IPerson Customer { get; init; }
	public int KmRented { get; init; }
	public double Cost { get; set; }
	public DateTime DateRented { get; init; }
	public int KmReturned { get; private set; }
	public string? DateReturned { get; private set; } 

	public BookingStatus Status { get; private set; }

    public Bookings(IVehicle vehicle, IPerson customer, int kmrented, DateTime daterented)
    {
		Vehicle = vehicle;
		Customer = customer;
		KmRented = kmrented;
		DateRented = daterented;
    }

	public void CloseBooking(int? km)
	{
		DateReturned = DateTime.Today.ToShortDateString();
		Status = BookingStatus.Closed;
		KmReturned += KmRented + (km ?? 0);
	}

    public void CalculateCost(double dailyPrice, double kmPrice, int kmRented, int kmReturned) => Cost =
    (dailyPrice + (kmPrice * (kmReturned - kmRented)));
}
