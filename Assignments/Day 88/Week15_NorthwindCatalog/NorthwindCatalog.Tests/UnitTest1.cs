using Xunit;
using NorthwindCatalog.Services.DTO;

public class ProductTests
{
    [Fact]
    public void InventoryValue_Should_Return_Correct_Value()
    {
        var product = new ProductDto
        {
            UnitPrice = 20,
            UnitsInStock = 3
        };

        var result = product.InventoryValue;

        Assert.Equal(60, result);
    }
}