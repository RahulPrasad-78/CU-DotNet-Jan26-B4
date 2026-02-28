namespace BonusCalculator
{
    public class Class1
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        //private int myVar;

        public double NetAnnualBonus
        {
            get {
                double bonus = 0 ;
                if (BaseSalary <= 0) return 0;
                
                if(PerformanceRating<1 || PerformanceRating > 5)
                {
                    throw new InvalidOperationException("Its Out of Range");
                }

                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Invalid Attendace");

                switch (PerformanceRating)
                {
                    case 5: bonus = (double)(BaseSalary * 0.25m);
                        break;
                    case 4:
                        bonus= (double)(BaseSalary * 0.18m);
                        break;
                    case 3:
                        bonus = (double)(BaseSalary * 0.12m);
                        break;
                    case 2:
                        bonus = (double)(BaseSalary * 0.5m);
                        break;
                    case 1:
                        break;
                }


                if (YearsOfExperience > 10) bonus += (double)(BaseSalary * 0.05m);
                else if(YearsOfExperience > 5) bonus += (double)(BaseSalary * 0.03m);


                if (AttendancePercentage < 85) bonus -= (double)(bonus * 0.2);

                bonus *= (double)DepartmentMultiplier;

                double totalBonus = Math.Min((double)(BaseSalary * 0.40m), bonus);

                if (totalBonus <= 150000)
                    totalBonus = totalBonus - (totalBonus * 0.10);
                else if(totalBonus > 300000) 
                    totalBonus = totalBonus - (totalBonus * 0.30);
                else
                    totalBonus = totalBonus - (totalBonus * 0.20);

                
                return Math.Round(totalBonus, 2); 
            }
        }
    }
}
