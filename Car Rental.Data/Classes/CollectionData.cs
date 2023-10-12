﻿using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Reflection;

namespace Car_Rental.Data;

public class CollectionData : IData
{
	List<IPerson> _people = new();
	List<IVehicle> _vehicles = new();
	List<IBookings> _bookings = new();

	public int NextPersonId => _people.Count.Equals(0) ? 1 : _people.Max(b => b.Id) + 1;
	public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    public CollectionData()
	{
		SeedData();
	}
	void SeedData()
	{
		_vehicles.Add(new Car(NextVehicleId, "LIT400", "VolksWagen", 9000, VehicleTypes.Hatchback, 1, 200));
		_vehicles.Add(new Car(NextVehicleId, "RAN999", "Volvo", 1000, VehicleTypes.MPV, 1.5, 300));
		_vehicles.Add(new Car(NextVehicleId, "KIA399", "KIA", 35000, VehicleTypes.SUV, 3, 50));
		_vehicles.Add(new Car(NextVehicleId, "RIK200", "Lexus", 3000, VehicleTypes.Sedan, 7.5, 400));
		_vehicles.Add(new Car(NextVehicleId, "FLY100", "Mercedes", 24500, VehicleTypes.Van, 1, 150));

		_vehicles.Add(new Motorcycle(NextVehicleId, "JJD123", "Honda", 2000, VehicleTypes.Motorcycle, 1.5, 300));

		_people.Add(new Person(NextPersonId, 870101, "Sven", "Svensson"));
		_people.Add(new Person(NextPersonId, 490231, "Kaj", "Kajsson"));
		_people.Add(new Person(NextPersonId, 015959, "Åsa", "Åsadotter"));
	}
	
	public void Add<T>(T x)
	{
		if (x is Person) _people.Add((IPerson)x);
		else if (x is Car || x is Motorcycle) _vehicles.Add((IVehicle)x);
		else if (x is Bookings) _bookings.Add((IBookings)x);
	}
	public IEnumerable<T> Get<T>(Func<T, bool>? predicate = null)
	{
		FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
		try
		{
			foreach (var f in fields)
			{
				if (typeof(List<T>) == f.FieldType)
				{
					var list = f.GetValue(this) as List<T> ?? throw new ArgumentNullException("Can't find list");
					return predicate is null ? list : list.Where(predicate);
				}
			}
		}
		catch
		{
			throw;
		}
		return new List<T>();
    }

}