namespace GlobalMart.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(decimal price, string coupon)
        {
            if(coupon == "WINTER25")
            {
                return price - (price * 0.25m);
            }
            return price;
        }
    }
}
