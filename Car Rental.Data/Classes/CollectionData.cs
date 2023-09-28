using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data;

public class CollectionData : IData
{
    readonly List<IPerson> _people = new();
	readonly List<IVehicle> _vehicles = new();
	readonly List<IBookings> _bookings = new();

	public CollectionData()
	{
		SeedData();
	}
	void SeedData()
	{
		int id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
		_vehicles.Add(new Car(id, 0, "LIT400", "VolksWagen", 9000, 1, 200));
		id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
		_vehicles.Add(new Car(id, 1, "RAN999", "Volvo", 1000, 1.5, 300));
		id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
		_vehicles.Add(new Car(id, 2, "KIA399", "KIA", 35000, 3, 50));
		id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
		_vehicles.Add(new Car(id, 3, "RIK200", "Lexus", 3000, 7.5, 400));
		id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
		_vehicles.Add(new Car(id, 4, "FLY100", "Mercedes", 24500, 1, 150));

        id = _vehicles.Count() == 0 ? 1 : _vehicles.Max(x => x.Id) + 1;
        _vehicles.Add(new Motorcycle(id, "JJD123", "Honda", 2000, 1.5, 300));

        id = _people.Count() == 0 ? 1 : _people.Max(x => x.Id) + 1;
		_people.Add(new Person(id, 870101, "Sven", "Svensson"));
        id = _people.Count() == 0 ? 1 : _people.Max(x => x.Id) + 1;
        _people.Add(new Person(id, 490231, "Kaj", "Kajsson"));
        id = _people.Count() == 0 ? 1 : _people.Max(x => x.Id) + 1;
        _people.Add(new Person(id, 015959, "Åsa", "Åsadotter"));

    }

	public IEnumerable<IPerson> GetPeople()
	{
		return _people;
	}
	public IEnumerable<IVehicle> GetVehicles()
	{
		return _vehicles;
	}
	public IEnumerable<IBookings> GetBookings()
	{
		return _bookings;
	}
}