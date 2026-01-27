using System.Threading.Channels;

namespace Inheritance
{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty; 
            PrincipalAmount = 0;
            TenureInYears = 0;
            
        }

        public Loan(string loan, string name, decimal amount, int year)
        {
            LoanNumber = loan;
            CustomerName = name;
            PrincipalAmount = amount;
            TenureInYears = year;
        }

        public double CalculateEMI()
        {
            Console.WriteLine("Loan Class CalculateEMI");
            double total = ((double)PrincipalAmount * 10 * TenureInYears)/100;
            Console.WriteLine($"Total from Loan class {total}");
            return total;
        }
    }

    class HomeLoan : Loan
    {
        public HomeLoan(string number, string name, decimal p, int year) : base(number, name,p, year)
        {
            Console.WriteLine("HomeLoan Constructor");
        }
        public HomeLoan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYears = 0;
        }
        public new double CalculateEMI()
        {
            Console.WriteLine("HomeLoan class");
            double total = 0;
            total = (double)(PrincipalAmount) * 0.09;
            total = total + CalculateEMI() + 15000.00;
            Console.WriteLine($"Total from HomeLoan class {total}");
            return (double)PrincipalAmount + total;
        }
    }

    class CarLoan : Loan
    {
        public CarLoan()
        {
            LoanNumber= string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount= 0;
            TenureInYears = 0;
        }
        public CarLoan(string number, string name, decimal p, int year) : base(number, name, p,year)
        {
            Console.WriteLine("Loan Constructor");
        }
        public new double CalculateEMI()
        {
            Console.WriteLine("CarLoan class");
            double total = 0;
            total = (double)(PrincipalAmount) * 0.08;
            total += (double)(PrincipalAmount) * 0.01;
            total = total + CalculateEMI();
            Console.WriteLine($"Total from CarLoan class {total}");
            return (double)PrincipalAmount + total;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Loan[] l = new Loan[]
            {
                new HomeLoan("Sneha", "Sneha", 678.0m, 6),
                new HomeLoan("sudhish","sudhish", 1678.0m, 8),
                new CarLoan("Rahul", "rahul", 2678.0m, 10),
                new CarLoan("Jai", "JAi", 3678.0m, 100)
            };

            for(int i =0; i< l.Length; i++)
            {
                Console.WriteLine();
                l[i].CalculateEMI();
            }
        }
    }
}
