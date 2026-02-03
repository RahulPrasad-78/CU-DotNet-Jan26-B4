using System.Collections;

namespace HashTable
{
    internal class HashTable
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            //CHECKING
            if (employeeTable.ContainsKey(105))
                Console.WriteLine("ID Already Exists");
            else
                employeeTable.Add(105, "Edward");

            // DATA  RETRIEVAL &  BOXING
            string? name = employeeTable[101] as string;
            Console.WriteLine($"Name of person {name}" );

            //Iteration
            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID - {item.Key}, Name - {item.Value}");
            }

            //DELETE
            employeeTable.Remove(103);
            Console.WriteLine("Total Count After Removing is : " + employeeTable.Count);


        }
    }
}
