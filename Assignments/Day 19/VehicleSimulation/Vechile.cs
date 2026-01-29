namespace VehicleSimulation
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }

        public abstract void Move();
        public virtual void GetFuelStatus()
        {
            Console.WriteLine("Fuel level is stable");
        }
    }

    class ElectricCar : Vehicle
    {

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }

        public override void GetFuelStatus()
        {
            Console.WriteLine($"{ModelName} battery is at 80%");
        }
    }

    class Heavytruck : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-Torque diesel power");
        }
    }

    class CargoPlane : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet");
        }

        public override void GetFuelStatus()
        {
            base.GetFuelStatus();
            Console.WriteLine($"Checking jet fuel reserves... ");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Vehicle[] arr = new Vehicle[3]
            {
                new ElectricCar(){ModelName = "Tesla"},
                new Heavytruck(){ModelName = "Koenigsegg"},
                new CargoPlane(){ModelName = "Rolls-Royce"},
            };

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Move();
                arr[i].GetFuelStatus();
                Console.WriteLine();
            }
        }
    }
}
