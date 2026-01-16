namespace BankTransaction
{
    internal class BankTransactionAnalyzer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Transactio Log");
            string input = Console.ReadLine();
            string[] inputs = input.Split('#', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string id = inputs[0];
            string name = inputs[1];
            string narration = inputs[2];

            narration = narration.ToLower();

            bool keyword = false;
            if (narration.Contains("deposite") || narration.Contains("withdrawal") || narration.Contains("transfer"))
            {
                 keyword = true;
            }
            bool compare = false;
            if(narration.Contains("cash deposite successful"))  compare = true;


            string status = null;
            if (!keyword)
            {
                status = "NON-FINANCIAl TRANSACTION";
            }
            else if(keyword && compare)
            {
                status = "STANDARD TRANSACTION";
            }
            else if(keyword && !compare)
            {
                status = "CUSTOM TRANSACTION";
            }


            Console.WriteLine($"Transaction ID :{id, -10}");
            Console.WriteLine($"Account Holder :{name,-10}");
            Console.WriteLine($"Narration      :{narration,-10}");
            Console.WriteLine($"Category       :{status,-10}");
        }
    }
}
