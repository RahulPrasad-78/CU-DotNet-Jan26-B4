using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    internal class Assignment_1
    {
        static void Main(string[] args)
        {
            //EXERCISE - 1

            int total = 80;
            Console.WriteLine("Total classes Attended in Maths");
            int math = int.Parse(Console.ReadLine());
            Console.WriteLine("Total classes Attended in Science");
            int science = int.Parse(Console.ReadLine());
            Console.WriteLine("Total classes Attended in English");
            int english = int.Parse(Console.ReadLine());

            double mathAtt = ((double)math / total) * 100;
            double sciAtt = ((double)science / total) * 100;
            double engAtt = ((double)english / total) * 100;

            Console.WriteLine();
            Console.WriteLine($"Your Attendance in Maths is" + Convert.ToInt32(mathAtt) +
                "% \nYour Attendance in Science is " + Convert.ToInt32(sciAtt) +
                "% \nYour Attendance in English is " + Convert.ToInt32(engAtt));
            // Rounding method will round of the value before converting to give a accurate answer
            //Truncation method will ignore the data after decimal
            /* I used truncation method as it will ignore the decimal for converting and
            */




            //EXERCISE - 2

            int eng = 80;
            int maths = 69;
            int sci = 78;

            double avg = Math.Round((eng + maths + sci) / 3.0, 2);
            Console.WriteLine("Your Average is " + avg);

            int av = (int)avg; // we are using explicit casting and due to that precision may be lost will conversion
            Console.WriteLine("For Scholorship Program Your Attendance is " + av);




            // EXERCISE - 3

            double fine = 1.67d;    //fine usually have fraction value.
            Console.WriteLine("Enter the Due date :");
            int dueDate = int.Parse(Console.ReadLine());    //days are whole numbers.
            decimal totalFine = (decimal)(fine * dueDate);
            /* we used explicit casting to covert fine and dueDate into decimal*/

            Console.WriteLine("Total Fine is " + totalFine);




            //EXERCISE - 4
            /* Implicit conversion from float to decimal is not allowed 
             * because float has lower precision and may cause data loss. */

            decimal bal = 1200.50m;
            float intrest = 0.067f;

            decimal rate = (decimal)intrest;
            decimal monthly = bal * rate;

            bal += monthly;
            Console.WriteLine("your balance after a month is " + bal);




            //EXRCISE - 5
            double cart = 673d;
            decimal tax = 0.45m;
            decimal discount = 24m;

            decimal fine1 = (decimal)cart * tax;
            Console.WriteLine("Your total payable amount is " + (fine1 - discount));
            /* Explicit Casting is required because we are Converting double into Decimal 
             this also increase the risk of precision */




            //EXERCISE - 6
            /*  */
            short t1 = 325; //suppose the reading is in kelvin 
            short t2 = 289;
            short t3 = 300;
            // short data type may run out of storage for large value and give a overflow

            double c1 = t1 - 273;
            double c2 = t2 - 273;
            double c3 = t3 - 273;
            //No casting mistake will occur in this code beacuse all conversion is safe

            double avgTemp = (c1 + c2 + c3) / 3;
            Console.WriteLine("AVerage Temperature is " + avgTemp);




            //EXERCISE - 7
            Console.WriteLine("ENter you Score");
            double score = int.Parse(Console.ReadLine());

            byte grade;

            if (score >= 90) grade = 10;    //Condition is used to prevent logical error
            else if (score >= 80) grade = 9;   
            else if (score >= 70) grade = 8;   
            else if (score >= 60) grade = 7;   
            else grade = 6;

            Console.WriteLine("Your final score is " + grade);




            //EXERCISE - 8
            long byteuse = 676982534;
            double mb = byteuse / (1024.0 * 1024.0);    // Implicit casting 
            double gb = byteuse / (1024.0 * 1024.0 * 1024.0);

            Console.WriteLine("Usage in MB: " + mb + "\nUsage in GB: " + gb);

            long rndMB = (long)Math.Round(mb);  // explicit casting
            long rndGB = (long)Math.Round(gb);
            // we are Rounding of the value and then converting them in long so there is risk of data loss and overflow

            Console.WriteLine("Round of Usage in MB: " + rndMB + "\nRound of Usage in GB: " + rndGB);




            //EXERCISE - 9
            Console.WriteLine("Enter the Number of Item: ");
            int item = int.Parse(Console.ReadLine());
            ushort capacity = 50000;

            if (item < (int)capacity) //Coverting the capacity into int for comparision
            {
                Console.WriteLine("WareHouse can store all the Item");
            }
            else
            {
                Console.WriteLine("WareHourse can't store all the Item");
            }
            // Signed and UnSigned have great Risk as Negative int values compared against ushort will give wrong output
            // Casting int into ushort can give Overflow




            //EXERCISE - 10
            int salary = 12000;
            double allo = 1200d;
            double dedu = 750.50d;

            decimal netSalary = salary + (decimal)allo - (decimal)dedu;
            // its explicit casting beacuse we are converting double into decimal

            Console.WriteLine("your Total money left is " + netSalary);


        }
    }
}
