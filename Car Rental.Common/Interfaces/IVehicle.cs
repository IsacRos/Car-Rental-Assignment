using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
	public int Id { get; init; }
	public VehicleTypes VehicleType { get; init; }
	public string RegNo { get; init; }
	public string Make { get; init; }
	public int Odometer { get; }
	public double KmCost { get; init; }
	public int Price { get; init; }
	public VehicleStatus Status { get; }

	public void IsBooked(bool status);

	public void UpdateOdometer(int? kM);

}
