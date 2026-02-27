namespace AbstractOverride
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        public abstract decimal CalculateBillAmount();
        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }

        public void PrintBill()
        {
            Console.WriteLine($"Customer ID    :    {ConsumerId}");
            Console.WriteLine($"Customer Name  :    {ConsumerName}");
            Console.WriteLine($"Units Consumed :    {UnitsConsumed}");
            Console.WriteLine($"Units          :    {RatePerUnit}");
            decimal amount = (decimal)CalculaateBillAmount() + (decimal)CalculateTax();

            Console.WriteLine($"Units          :    {amount}");
        }
    }

    class ElectricityBill : UtilityBill
    {

    }


    internal class TariffCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
