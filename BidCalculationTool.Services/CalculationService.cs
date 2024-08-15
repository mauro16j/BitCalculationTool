using BidCalculationTool.Models.DTO;
using BidCalculationTool.Models.Enum;
using BidCalculationTool.Services.Factory;
using BidCalculationTool.Services.Interfaces;

namespace BidCalculationTool.Services;

public class CalculationService : ICalculationService
{
    public VehicleFee CalculateVehicleFees(decimal basePrice, Vehicle type)
    {
        if(basePrice <= 0)
        {
            throw new ArgumentException("Price must be greater than zero");
        }

        var vehicleType = VehicleTypeFactory.CreateVehicleType(type);

        var baseFee = vehicleType.CalculateBaseFee(basePrice);
        var sellerFee = vehicleType.CalculateSellerSpecialFee(basePrice);
        var associationFee = vehicleType.CalculateAssociationFee(basePrice);
        var storageFee = vehicleType.CalculateStorageFee();

        var total = basePrice + baseFee + sellerFee + associationFee + storageFee;

        return new VehicleFee(baseFee,associationFee,sellerFee, storageFee, total);
    }

}
