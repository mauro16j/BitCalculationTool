namespace BidCalculationTool.Services.Factory;

public class CommonVehicle : VehicleType
{
    public override decimal CalculateBaseFee(decimal price)
    {
        decimal fee = price * 0.10m;
        return Math.Clamp(fee, 10m, 50m);
    }
    public override decimal CalculateSellerSpecialFee(decimal price)
    {
        return price * 0.02m;
    }
}
