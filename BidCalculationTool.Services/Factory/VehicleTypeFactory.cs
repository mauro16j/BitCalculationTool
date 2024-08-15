using BidCalculationTool.Models.Enum;

namespace BidCalculationTool.Services.Factory;

public static class VehicleTypeFactory
{
    public static VehicleType CreateVehicleType(Vehicle type)
    {
        return type switch
        {
            Vehicle.Common => new CommonVehicle(),
            Vehicle.Luxury => new LuxuryVehicle(),
            _ => throw new ArgumentException("Invalid type")
        };
    }
}
