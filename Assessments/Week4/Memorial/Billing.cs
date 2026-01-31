namespace Memorial
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public Patient(string name, decimal baseFee)
        {
            this.Name = name;
            this.BaseFee = baseFee;

        }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class Inpatient : Patient
    {
        public int DayStayed { get; set; }
        public decimal DailyRate { get; set; }

        public Inpatient(string name, decimal baseFee, int days, decimal rate) : base(name, baseFee)
        {
            this.DayStayed = days;
            this.DailyRate = rate;
        }

        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill() + (DayStayed * DailyRate);
        }

    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public Outpatient(string name, decimal baseFee, decimal fee) : base(name, baseFee)
        {
            this.ProcedureFee = fee;
        }

        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill() + ProcedureFee;
        }
    }

    class Emergencypatient : Patient
    {
        public int SeverityLevel { get; set; }
        public Emergencypatient(string name, decimal baseFee, int lvl) : base(name, baseFee)
        {
            this.SeverityLevel = lvl;
        }

        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill() * SeverityLevel;
        }
    }

    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }
        public void GenerateDailyReport()
        {
            foreach (Patient patient in patients)
            {
                Console.WriteLine($"Name - {patient.Name}, Total Bill - ${patient.CalculateFinalBill():F2}");
            }
        }

        public void CalculateTotalREvenue()
        {
            decimal total = 0;
            foreach (Patient patient in patients)
            {
                total += patient.CalculateFinalBill();
            }
            Console.WriteLine("Total Revenue " + total);
        }

        public void GetInPatientCount()
        {
            int count = 0;
            foreach(Patient patient in patients)
            {
                if (patient is Inpatient) count++;
            }
            Console.WriteLine($"Total {count} patient is Inpatient");
        }
    }
    internal class Billing
    {
        static void Main(string[] args)
        {
            HospitalBilling hospital = new HospitalBilling();
            hospital.AddPatient(new Emergencypatient("Rahul", 2500, 4));
            hospital.AddPatient(new Emergencypatient("Vansh", 3000, 4));
            hospital.AddPatient(new Outpatient("Rohan", 4000, 3000));
            hospital.AddPatient(new Inpatient("Ram", 2000, 7, 450.50m));
            hospital.AddPatient(new Inpatient("Yash", 3500, 10, 350.00m));
            Console.WriteLine("----------------------------------------------------");
            
            hospital.GenerateDailyReport();
            Console.WriteLine("----------------------------------------------------");

            hospital.CalculateTotalREvenue();
            Console.WriteLine("----------------------------------------------------");

            hospital.GetInPatientCount();

        }
    }
}
