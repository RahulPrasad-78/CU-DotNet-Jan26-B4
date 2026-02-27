using System;
using System.Collections.Generic;

namespace SmartKitchenSystem
{
    interface ITimerFeature
    {
        void SetTimer(int minutes);
    }

    interface IWifiEnabled
    {
        void ConnectToWifi();
    }

    abstract class KitchenAppliance
    {
        public int PowerInWatts { get; set; }
        public string Model { get; set; }

        protected KitchenAppliance(int power, string model)
        {
            PowerInWatts = power;
            Model = model;
        }

        public abstract void StartCooking();

        public virtual void PreHeat()
        {
            Console.WriteLine("Default preheating process...");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model} | Power: {PowerInWatts}W");
        }
    }

    class MicrowaveOven : KitchenAppliance, ITimerFeature
    {
        public MicrowaveOven(int power, string model) : base(power, model) { }

        public void SetTimer(int minutes)
        {
            if (minutes > 0)
                Console.WriteLine($"Microwave timer set to {minutes} minutes.");
            else
                Console.WriteLine("Invalid timer value.");
        }

        public override void StartCooking()
        {
            Console.WriteLine("Microwave is warming the food.");
        }
    }

    class SmartOven : KitchenAppliance, ITimerFeature, IWifiEnabled
    {
        public SmartOven(int power, string model) : base(power, model) { }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Smart Oven timer set to {minutes} minutes.");
        }

        public void ConnectToWifi()
        {
            Console.WriteLine("Smart Oven successfully connected to WiFi.");
        }

        public override void PreHeat()
        {
            Console.WriteLine("Smart Oven is preheating...");
        }

        public override void StartCooking()
        {
            PreHeat();
            Console.WriteLine("Smart Oven started cooking.");
        }
    }

    class AirFryerPro : KitchenAppliance
    {
        public AirFryerPro(int power, string model) : base(power, model) { }

        public override void StartCooking()
        {
            Console.WriteLine("Air Fryer is crisping the food.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenAppliance> applianceList = new List<KitchenAppliance>
            {
                new MicrowaveOven(800, "HeatMaster 800"),
                new SmartOven(2200, "SmartBake X"),
                new AirFryerPro(1800, "Philips Airfryer")
            };

            foreach (var appliance in applianceList)
            {
                appliance.DisplayInfo();
                appliance.StartCooking();

                if (appliance is ITimerFeature timerDevice)
                {
                    timerDevice.SetTimer(15);
                }

                if (appliance is IWifiEnabled wifiDevice)
                {
                    wifiDevice.ConnectToWifi();
                }

                Console.WriteLine("----------------------------------");
            }
        }
    }
}
