using System.Transactions;

namespace OrderProcessingSystem
{
    internal class ProcessingSystem
    {
        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Day {i + 1} = ");
                sales[i] = decimal.Parse(Console.ReadLine());
                if (sales[i] < 0)
                {
                    i--;
                    Console.WriteLine("Negative Value not Permitted");
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++) total += sales[i];
            return total;

        }

        static int FindHighestSale(decimal[] sales)
        {
            int highest = 0;
            decimal sum = sales[0];
            for (int i = 1; i < sales.Length; i++)
            {
                if (sum < sales[i])
                {
                    highest = i;
                    sum = sales[i];
                }
            }
            return highest;
        }

        static int FindLowestSale(decimal[] sales)
        {
            int lowest = 0;
            decimal sum = sales[0];
            for (int i = 1; i < sales.Length; i++)
            {
                if (sum > sales[i])
                {
                    lowest = i;
                    sum = sales[i];
                }
            }
            return lowest;
        }

        static decimal CalculateAverage(decimal[] sales, decimal total)
        {
            return total / sales.Length;
        }


        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000) return (10m / 100m) * total;
            return (5m / 100m) * total;
        }

        static decimal CalculateDiscount(decimal total, bool isFestival)
        {
            if (total >= 50000) return (15m / 100m) * total;
            return (10m / 100m) * total;
        }


        static decimal CalculateTax(decimal total, decimal discount)
        {
            return (18m / 100m) * (total - discount);
        }


        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount - tax;
        }


        static void GenerateSalesCategory(decimal[] sales, string[] category)
        {
            for (int i = 0; i < 7; i++)
            {
                if (sales[i] < 5000) category[i] = "Low";
                else if (sales[i] > 15000) category[i] = "High";
                else category[i] = "Medium";
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Daily Sales Value");
            decimal[] sales = new decimal[7];

            ReadWeeklySales(sales);
            //Console.WriteLine(String.Join(" ", sales));

            decimal total = CalculateTotal(sales);
            decimal average = CalculateAverage(sales, total);

            int highestDay = FindHighestSale(sales);
            int lowestDay = FindLowestSale(sales);

            bool festival = true;
            decimal discount = 0;
            if (festival) discount = CalculateDiscount(total, festival);
            else discount = CalculateDiscount(total);

            decimal tax = CalculateTax(total, discount);
            decimal finalAmount = CalculateFinalAmount(total, discount, tax);

            string[] category = new string[7];
            GenerateSalesCategory(sales, category);

            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine($"Total Sales            : {total}");
            Console.WriteLine($"Average Sales          : {average}");
            Console.WriteLine($"\nHighest Sales          : {sales[highestDay]:F2} (Day {highestDay})");
            Console.WriteLine($"Total Sales            : {sales[lowestDay]} (Day {lowestDay})");
            Console.WriteLine($"\nDiscount Applied       : {discount}");
            Console.WriteLine($"Tax Amount             : {tax}");
            Console.WriteLine($"Final Amount           : {finalAmount}");

            Console.WriteLine("\nDay-Wise Category");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1} = {category[i]}");
            }
        }
    }
}
