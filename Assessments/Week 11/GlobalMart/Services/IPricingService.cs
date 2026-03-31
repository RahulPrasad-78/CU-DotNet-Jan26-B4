namespace GlobalMart.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal price, string coupon);
    }
}
