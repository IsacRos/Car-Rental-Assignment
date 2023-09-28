using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data;

namespace Car_Rental.Business;

public class BookingProcessor
{

	public CollectionData _data = new();

	public List<IVehicle> _vehicles = new();
    public List<IPerson> _people = new();
    public List<IBookings> _bookings = new();

    public int? returnKm;

    public BookingProcessor()
    {
        _vehicles = _data.GetVehicles().ToList();
        _people = _data.GetPeople().ToList();
        _bookings = _data.GetBookings().ToList();
    }

    public void RentCar(IVehicle v)
    {
        var booking = new Bookings(v.RegNo, "john", v.Odometer, DateTime.Now);
        _bookings.Add(booking);
        _vehicles.Single(v => v.RegNo == booking.RegNo).IsBooked(true);
    }

    public void ReturnCar(IBookings b)
    {
        IVehicle v = _vehicles.Single(v => v.RegNo == b.RegNo);
        b.CloseBooking(returnKm);
        v.UpdateOdometer(returnKm);
        b.CalculateCost(v.Price, v.KmCost, b.KmRented, b.KmReturned);
        v.IsBooked(false);
        returnKm = null;
    }


}