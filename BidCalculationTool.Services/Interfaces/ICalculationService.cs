using BidCalculationTool.Models.DTO;

namespace BidCalculationTool.Services.Interfaces;

public interface ICalculationService
{
    VehicleFee CalculateVehicleFees(decimal basePrice, int type);
}
