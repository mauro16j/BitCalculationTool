using BidCalculationTool.Models.DTO;
using BidCalculationTool.Services.Interfaces;

namespace BidCalculationTool.Services;

public class CalculationService : ICalculationService
{
    public VehicleFee CalculateVehicleFees(decimal basePrice, int type)
    {
        var baseFee = CalculateBaseFee(basePrice, type);
        var sellerFee = CalculateSellerSpecialFee(basePrice, type);
        var associationFee = CalculateAssociationFee(basePrice);

        var total = basePrice + baseFee + sellerFee + associationFee + 100;

        return new VehicleFee(baseFee,associationFee,sellerFee,100, total);
    }

    private decimal CalculateBaseFee(decimal price, int type)
    {
        decimal fee = price * 0.10m;

        return (type) switch
        {
            1 => Math.Clamp(fee, 10m, 50m),
            2 => Math.Clamp(fee, 25m, 200m),
            _ => throw new ArgumentException("Invalid type")
        };
    }

    private decimal CalculateSellerSpecialFee(decimal price, int type)
    {
        return (type) switch
        {
            1 => price * 0.02m,
            2 => price * 0.04m,
            _ => throw new ArgumentException("Invalid type")
        };
    }

    private decimal CalculateAssociationFee(decimal price)
    {
        return (price) switch
        {
            decimal i when i > 0 && i <= 500 => 5,
            decimal i when i > 500 && i <= 1000 => 10,
            decimal i when i > 1000 && i <= 3000 => 15,
            _ => 20
        };
    }
}
