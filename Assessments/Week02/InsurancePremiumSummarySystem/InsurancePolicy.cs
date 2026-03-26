using System.ComponentModel;

namespace InsurancePremiumSummarySystem
{
    internal class InsurancePolicy
    {

        static void validation(string[] policyHolderName, decimal[] annualPreminums)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter the Policy Holder Name: ");
                policyHolderName[i] = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(policyHolderName[i]))
                {
                    Console.WriteLine("Enter the name Correctly");
                    i--;
                    continue;
                }

                Console.Write($"Enter the Annual Amount of {policyHolderName[i]}: ");
                annualPreminums[i] = decimal.Parse(Console.ReadLine());
                if (annualPreminums[i] < 0)
                {
                    Console.WriteLine("Amount should be greater than 0");
                    i--;
                }
            }
        }

        public static void Main(string[] args)
        {
            string[] policyHolderName = new string[5];
            decimal[] annualPreminums = new decimal[5];

            //Console.WriteLine(decimal.MaxValue);
            validation(policyHolderName, annualPreminums);

            decimal totalAMount = 0;
            decimal averageAmount = 0;
            decimal highest = 0;
            decimal lowest = decimal.MaxValue;

            for(int i = 0;i < 5; i++)
            {
                highest = Math.Max(highest, annualPreminums[i]);
                lowest = Math.Min(lowest, annualPreminums[i]);
                totalAMount += annualPreminums[i];
            }
            averageAmount = totalAMount / 5;

            Console.WriteLine("\nSummary");
            Console.WriteLine();
            Console.WriteLine($"{"Name", -10} | {"Amount", -10} | {"Category", 7}");

            for(int i = 0; i < 5; i++)
            {
                if (annualPreminums[i] < 10000)
                {
                    Console.WriteLine($"{policyHolderName[i].ToUpper(),-10}     {annualPreminums[i],-10:F2}    {"Low", 5}");
                }
                else if (annualPreminums[i]> 25000)
                {
                    Console.WriteLine($"{policyHolderName[i].ToUpper(),-10}     {annualPreminums[i],-10:F2}    {"HIGH", 5}");
                }
                else
                {
                    Console.WriteLine($"{policyHolderName[i].ToUpper(),-10}     {annualPreminums[i],-10:F2}    {"MEDIUM", 5}");
                }
            }

            Console.WriteLine($"\nTotal Premium      :{totalAMount,-2:F2}");
            Console.WriteLine($"Average Premium    :{averageAmount,-2:F2}");
            Console.WriteLine($"Highest premium    :{highest,-2:F2}");
            Console.WriteLine($"Lowest Premium     :{lowest,-2:F2}");

        }
    }
}
