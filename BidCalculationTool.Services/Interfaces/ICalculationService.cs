using BidCalculationTool.Models.DTO;
using BidCalculationTool.Models.Enum;

namespace BidCalculationTool.Services.Interfaces;

public interface ICalculationService
{
    VehicleFee CalculateVehicleFees(decimal basePrice, Vehicle type);
}
