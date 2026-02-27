using System.Threading.Channels;

namespace GymCharges
{
    internal class GYM
    {
        //static double CalculateGymBill(bool treadMill, bool weight, bool zumba)
        //{
        //    //double amount = 1000.00;
        //    //amount += treadMill ? 300.00 : 0.00;
        //    //amount += weight ? 500.00 : 0.00;
        //    //amount += zumba ? 250.00 : 0.00;

        //    //if(amount == 1000.00)
        //    //{
        //    //    Console.WriteLine("No Service Opted, and you are fined");
        //    //    amount += 500;
        //    //}
        //    //amount += amount * 0.05; 

        //    //return (amount);
        //}

        static void Display(char dis = '-', int num = 40)
        {
            for(int i = 0; i< num; i++)
            {
                Console.Write(dis);
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {

            ////bool treadMill = bool.Parse(Console.ReadLine());
            //double total = CalculateGymBill(false, false, false);
            //Console.WriteLine($"Bill: {total:f2}");
            Display('+', 60);
            Display(num:'$');
            Display(num:100);
            Display();

        }
    }
}
