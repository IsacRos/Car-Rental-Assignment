using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
	IEnumerable<IPerson> GetPeople();
	IEnumerable<IVehicle> GetVehicles();
	IEnumerable<IBookings> GetBookings();
}
