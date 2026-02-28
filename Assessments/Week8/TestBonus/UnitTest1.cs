using BonusCalculator;
namespace TestBonus
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var emp = new Class1()
            {
                BaseSalary = 500000m,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };

            Assert.AreEqual(123200.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void Test2()
        {
            var emp = new Class1()
            {
                BaseSalary = 400000m,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };

            Assert.AreEqual(60480.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void Test3()
        {
            var emp = new Class1()
            {
                BaseSalary = 1000000m,
                PerformanceRating = 5,
                YearsOfExperience = 15,
                DepartmentMultiplier = 1.5m,
                AttendancePercentage = 95
            };

            Assert.AreEqual(280000.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void Test4()
        {
            var emp = new Class1()
            {
                BaseSalary = 0m,
            };

            Assert.AreEqual(0.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void Test5()
        {
            var emp = new Class1()
            {
                BaseSalary = 600000m,
                PerformanceRating = 3,
                YearsOfExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };

            Assert.AreEqual(64800.00m, emp.NetAnnualBonus);
        }

        [Test]
        public void Test6()
        {
            var emp = new Class1()
            {
                BaseSalary = 900000m,
                PerformanceRating = 5,
                YearsOfExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100
            };

            Assert.AreEqual(226800.00m, emp.NetAnnualBonus);
        }
    }
}