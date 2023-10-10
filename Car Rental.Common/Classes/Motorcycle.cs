using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(int id, string regno,
        string make, int odometer, VehicleTypes vehicleType, double kmcost, double price, int status = 0)
        : base(id, regno, make, odometer, vehicleType, kmcost, price, status)
    {}
}
