namespace Employee
{
    class EmployeeData
    {
        private int id;
        public void SetID(int id)
        {
            this.id = id; 
        }
        public int GetId(int id)
        {
            return id;
        }

        public string Name { get; set; }

        private string department;
        public string Department
        {
            get { return department; }
            set {
                if(value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }
                else
                {
                    Console.WriteLine("Wrong Department");
                    Console.WriteLine();
                }
            }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { 
                if(value>=50000 && value <= 90000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Your Salary is in Wrong Range");
                    Console.WriteLine();
                }
            }
        }

        public void Display()
        {
            Console.WriteLine($"ID         :{id, -10}");
            Console.WriteLine($"Name       :{Name, -10}");
            Console.WriteLine($"Department :{department, -10}");
            Console.WriteLine($"Salary     :{salary, -10}");
        }


    }

    internal class Employees
    {

        static void Main(string[] args)
        {
            EmployeeData emp = new EmployeeData();
            emp.SetID(2);
            emp.Name = "Rahul";
            emp.Salary = 75000;
            emp.Department = "Sales";
            emp.Display();

        }
    }
}
