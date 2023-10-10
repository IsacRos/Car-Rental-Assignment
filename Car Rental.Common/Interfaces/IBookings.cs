using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBookings
{
    public int Id { get; init; }
    public IVehicle Vehicle { get; init; }
    public IPerson Customer { get; init; }
    public int KmRented { get; init; }
    public double Cost { get; set; }
    public DateTime DateRented { get; init; }
    public int KmReturned { get; }
    public string? DateReturned { get; }

    public BookingStatus Status { get; }

    public void CloseBooking(int? km);

	public void CalculateCost(double dailyPrice, double kmPrice, int kmRented, int kmReturned);
}

