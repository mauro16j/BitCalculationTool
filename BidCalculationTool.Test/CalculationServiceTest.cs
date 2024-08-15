using BidCalculationTool.Models.Enum;
using BidCalculationTool.Services;

namespace BidCalculationTool.Test
{
    public class CalculationServiceTest
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTest()
        {
            _calculationService = new CalculationService();
        }

        [Theory]
        [InlineData(398, 1, 550.76)]
        [InlineData(501, 1, 671.02)]
        [InlineData(57, 1, 173.14)]
        [InlineData(1800, 2, 2167.00)]
        [InlineData(1100, 1, 1287.00)]
        [InlineData(1000000, 2, 1040320.00)]
        public void CalculateTaxes_ShouldReturnExpectedTotal(decimal price, int type, decimal expectedTotal)
        {
            // Act  
            var result = _calculationService.CalculateVehicleFees(price, (Vehicle)type);

            // Assert
            Assert.Equal(expectedTotal, result.Total);
        }
        [Fact]
        public void CalculateTaxes_ShouldThrowBadRequest_WhenPriceIsNotGreaterThanZero()
        {
            // Arrange
            decimal price = 0;
            int type = 1;

            // Act  

            // Assert
            Assert.Throws<ArgumentException>(() => _calculationService.CalculateVehicleFees(price, (Vehicle)type));
        }
    }
}
