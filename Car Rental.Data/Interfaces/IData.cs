using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using System.Reflection;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    public int NextPersonId { get; }
    public int NextVehicleId { get; }
    public int NextBookingId { get; }
    public void Add<T>(T x);
    public IEnumerable<T> Get<T>(Func<T, bool>? predicate = null);
   
}
