using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public int Id { get; init; }
    public VehicleTypes VehicleType { get; init; }
    public string RegNo { get; init; }
    public string Make { get; init; }
    public int Odometer { get; private set; }
    public double KmCost { get; init; }
    public double Price { get; init; }
    public VehicleStatus Status { get; private set; }

    public Vehicle(int id, string regno,
        string make, int odometer, VehicleTypes vehicleType, double kmcost, double price, int status = 0)
    {
        Id = id;
        VehicleType = vehicleType;
        RegNo = regno;
        Make = make;
        Odometer = odometer;
        KmCost = kmcost;
        Price = price;
        Status = (VehicleStatus)status;
    }
    public void IsBooked(bool status) => Status = status == true ? VehicleStatus.Booked : VehicleStatus.Available;
    public void UpdateOdometer(int? kM) => Odometer += kM ?? 0;
}
