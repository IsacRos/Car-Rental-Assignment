using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business;

public class BookingProcessor
{
    IData _data;

    #region Variables
    
    public string error = string.Empty;

    public int? tempSsn = null;
    public string[] tempName = Enumerable.Repeat(string.Empty, 2).ToArray();

    public string[] tempVehicle = Enumerable.Repeat(string.Empty, 2).ToArray();
    public int? returnKm;
    public int? tempOdometer;
    public double? tempCost;
    public double? tempPrice;

    public int selectedPerson = 0;
    public string processing = string.Empty;
    public bool processBool = false;

    public VehicleTypes chooseVehicle = new();
    #endregion

    public BookingProcessor(IData data) => _data = data;
    public async Task RentCar(IVehicle v)
    {
        try
        {
            error = string.Empty;
            if (selectedPerson < 1) throw new ArgumentException("Please select customer");
            processing = "Processing";
            processBool = true;
            await Task.Delay(10000);
            processBool = false;
            processing = string.Empty;

            var customer = GetPerson(selectedPerson);
            var booking = new Bookings(v, customer, v.Odometer, DateTime.Today);
            _data.Add<IBookings>(booking);
            v.IsBooked(true);
            selectedPerson = 0;
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }
    public void ReturnCar(IBookings b)
    {
        try
        {
            error = string.Empty;
            if (returnKm < 0)
                throw new ArgumentException("Can't return with negative Km");
            var v = _data.Get<IVehicle>(v => v.Id == b.Vehicle.Id).FirstOrDefault() ??
                throw new ArgumentNullException("Couldn't find vehicle");
            b.CloseBooking(returnKm);
            v.UpdateOdometer(returnKm);
            b.CalculateCost(v.Price, v.KmCost, b.KmRented, b.KmReturned);
            v.IsBooked(false);
            returnKm = null;
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }

    public void AddPerson()
    {
        try
        {
            error = string.Empty;

            if (tempSsn?.ToString().Length != 6) 
                throw new ArgumentException("SSN Must contain 6 numbers");
            else if (tempName[0] == string.Empty || tempName[1] == string.Empty) 
                throw new ArgumentException("Names can't be empty");

            Person person = new(_data.NextPersonId, (int)tempSsn, tempName[1], tempName[0]);
            _data.Add<IPerson>(person);
            (tempName[0], tempName[1]) = (string.Empty, string.Empty);
            tempSsn = null;
        }
        catch (Exception ex) { error = ex.Message; }
    }
    public void AddVehicle()
    {
        try
        {
            error = string.Empty;

            if (tempVehicle[0].Length != 6)
                throw new ArgumentException("RegNo must contain 6 characters");
            else if (tempVehicle[1].Length < 1)
                throw new ArgumentException("Please enter the make of the vehicle");
            else if (tempOdometer < 1 || tempOdometer is null)
                throw new ArgumentException("Odometer input can't be less than 1");
            else if (tempCost < 0.1 || tempPrice < 0.1 || tempCost is null || tempPrice is null) 
                throw new ArgumentException("Please enter price info correctly");

            Vehicle vehicle;
            if (chooseVehicle == VehicleTypes.Motorcycle)
                vehicle = new Motorcycle(_data.NextVehicleId, tempVehicle[0], tempVehicle[1],
                    (int)tempOdometer, chooseVehicle, (double)tempCost, (double)tempPrice);
            else
                vehicle = new Car(_data.NextVehicleId, tempVehicle[0], tempVehicle[1], 
                    (int)tempOdometer, chooseVehicle, (double)tempCost, (double)tempPrice);

            _data.Add<IVehicle>(vehicle);
            (tempVehicle[0], tempVehicle[1]) = (string.Empty, string.Empty);
            tempOdometer = null;
            tempCost = null;
            tempPrice = null;
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }    
    public IEnumerable<IPerson> GetPeople() =>_data.Get<IPerson>();
    public IEnumerable<IVehicle> GetVehicles() => _data.Get<IVehicle>();
    public IEnumerable<IBookings> GetBookings() => _data.Get<IBookings>();
    public IPerson GetPerson(int id)
    {
        try
        {
            return _data.Get<IPerson>(p => p.Id == id).FirstOrDefault() ??
                throw new ArgumentNullException("Couldn't find person");
        }
        catch (ArgumentNullException ex)
        {
            error = ex.Message;
            throw;
        }
    }

}