namespace BidCalculationTool.Services.Factory;

public class LuxuryVehicle : VehicleType
{
    public override decimal CalculateBaseFee(decimal price)
    {
        decimal fee = price * 0.10m;
        return Math.Clamp(fee, 25m, 200m);
    }
    public override decimal CalculateSellerSpecialFee(decimal price)
    {
        return price * 0.04m;
    }
}
