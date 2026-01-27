using System.Reflection.Metadata.Ecma335;

namespace EmployeeCompensation
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYear { get; set; }

        public Employee()
        {
            EmployeeID = 0;
            EmployeeName = string.Empty;
            BasicSalary = 0;
            ExperienceInYear = 0;
        }
        public Employee(int id, string name, decimal salary, int year)
        {
            EmployeeID = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYear = year;
        }

        public decimal CalculateAnnualSalary()
        {
            return BasicSalary*12; 
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}");
            Console.WriteLine($"Employee Name : {EmployeeName}");
            Console.WriteLine($"Basic Salary : {BasicSalary}");
            Console.WriteLine($"Annual Salary : {CalculateAnnualSalary()}");
            Console.WriteLine($"Experience : {ExperienceInYear}");
           
        }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int year):base(id, name, salary, year)
        {
            
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal total = BasicSalary*12;
            total += total * 0.3m;
            total += ExperienceInYear >= 5 ? 50000 : 0;
            return total;
        }
    }

    class ContractEmployee : Employee
    {
        public int ContractDurationMonths { get; set; }
        public ContractEmployee(int id, string name, decimal salary, int year, int months) : base(id, name, salary, year)
        {
            ContractDurationMonths = months;
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal total = BasicSalary*12;
            total += ExperienceInYear >= 12 ? 30000 : 0;
            return total;
        }
    }

    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int year) : base(id, name, salary, 0)
        {

        }

        public new decimal CalculateAnnualSalary()
        {
            decimal total = BasicSalary*12;
            return total;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new PermanentEmployee(101, "Rahul", 20000, 4);
            PermanentEmployee e2 = new PermanentEmployee(102, "Rohan", 20000, 8);

            Employee e3 = new ContractEmployee(103, "Rajat", 30000, 7, 9);
            ContractEmployee e4 = new ContractEmployee(104, "Rohit", 30000, 12, 10);

            Employee e5 = new InternEmployee(105, "Ramesh", 15000, 0);
            InternEmployee e6 = new InternEmployee(106, "Ram", 15000, 1);

            Console.WriteLine("Base Class");
            Console.WriteLine($"Employee 1 Salary : {e1.CalculateAnnualSalary()}");
            Console.WriteLine($"Employee 3 Salary : {e3.CalculateAnnualSalary()}");
            Console.WriteLine($"Employee 5 Salary : {e5.CalculateAnnualSalary()}");

            Console.WriteLine("\nDerived Class");
            Console.WriteLine($"Employee 2 Salary : {e2.CalculateAnnualSalary()}");
            Console.WriteLine($"Employee 4 Salary : {e4.CalculateAnnualSalary()}");
            Console.WriteLine($"Employee 6 Salary : {e6.CalculateAnnualSalary()}");
        }
    }
}
