
namespace BidCalculationTool.Services.Factory;

public abstract class VehicleType
{
    public abstract decimal CalculateBaseFee(decimal price);
    public abstract decimal CalculateSellerSpecialFee(decimal price);
    public decimal CalculateAssociationFee(decimal price)
    {      
        return (price) switch
        {
            decimal i when i > 0 && i <= 500 => 5,
            decimal i when i > 500 && i <= 1000 => 10,
            decimal i when i > 1000 && i <= 3000 => 15,
            _ => 20
        };   
    }
    public decimal CalculateStorageFee() => 100;

}
