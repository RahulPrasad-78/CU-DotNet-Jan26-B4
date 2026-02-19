using System.Runtime.ConstrainedExecution;

namespace ExpenseSplitter
{
    internal class Expenses
    {
        static List<string> SettleExpenseShare(Dictionary<string, double> expenses)
        {
            List<string> Settlement = new List<string>();

            // Creditors or Debitors
            Queue<KeyValuePair<string, double>> payers = new Queue<KeyValuePair<string, double>>();

            Queue<KeyValuePair<string, double>> receivers = new Queue<KeyValuePair<string, double>>();

            var totalExpense = expenses.Values.Sum();
            var person = expenses.Count;

            var share = totalExpense / person;
            
            foreach(var per in expenses)
            {
                if(per.Value > share)
                {
                    receivers.Enqueue(new KeyValuePair<string, double>(per.Key, per.Value - share)); 
                }
                else if(per.Value < share)
                {
                    payers.Enqueue(new KeyValuePair<string, double>(per.Key, share - per.Value ));
                }
            }

            //Settlement
            while(payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();

                var amount = Math.Min(payer.Value, receiver.Value);

                Settlement.Add($"{payer.Key},{receiver.Key},{amount}");
                
                if (payer.Value > amount)
                {
                    payers.Enqueue(new KeyValuePair<string, double>(payer.Key, Math.Abs(amount - payer.Value)));
                }

                if(receiver.Value > amount)
                {
                    receivers.Enqueue(new KeyValuePair<string, double>(receiver.Key, Math.Abs(amount - receiver.Value)));
                }
                //Console.WriteLine("Hello");
            }

            return Settlement;
        }
        static void Main(string[] args)
        {
            Dictionary<string, double> expense = new Dictionary<string, double>()
            {
                {"Rahul", 1000 }, 
                {"Rohan", 2000 }, 
                {"Jai", 7000 }, 
                {"Ayush", 10000 }, 
            };

            List<string> settlement = SettleExpenseShare(expense);

            foreach (var item in settlement)
            {
                Console.WriteLine(item);
            }
        }
    }
}
