namespace Cargo
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }
    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }
        public Container(string containerID, List<Item> items)
        {
            ContainerID = containerID;
            Items = items;
        }
    }
    internal class Program
    {
        static List<string> FindHeavyContainers(double weightThreshold, List<List<Container>> cargoBay)
        {
            return cargoBay.SelectMany(r => r).Where(x => x.Items
                    .Sum(i => i.Weight) > weightThreshold)
                    .Select(id =>id.ContainerID).OrderBy(a => a).ToList();
        }

        static Dictionary<string, int> GetitemCountsByCategory(List<List<Container>> cargoBay)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            foreach (var row in cargoBay)
            {
                foreach (var number in row)
                {
                    foreach (var item in number.Items)
                    {
                        if (res.ContainsKey(item.Category)) res[item.Category]++;
                        else res.Add(item.Category, 1);
                    }
                }
            }

            return res;
        }

        static public List<Item> FlattenAndSortShipment(List<List<Container>> cargoBay)
        {
            if (cargoBay == null)
                return new List<Item>();
            var newList = cargoBay.Where(r => r != null)
                                  .SelectMany(r => r)
                                  .Where(con => con != null && con.Items != null)
                                  .SelectMany(con => con.Items)
                                  .Where(it => it != null)
                                  .OrderBy(it => it.Category)
                                  .ThenByDescending(it => it.Weight)
                                  .ToList();
            return newList;
        }
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                // ROW 0: High-Value Tech Rows
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),

                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"),
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),

                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2: Fragile & Perishables
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),

                    new Container("C206", new List<Item>())
                },

                // ROW 3: Empty Row
                new List<Container>()
            };


            //////////////////////////////////////////////////////////////////////

            Console.WriteLine("Enter the Threshold");
            double weightThreshold = int.Parse(Console.ReadLine());
            List<string> container = FindHeavyContainers(weightThreshold, cargoBay);
            foreach (var containers in container)
            {
                Console.WriteLine("\t" + containers);
            }

            //////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine();
            Dictionary<string, int> ans = GetitemCountsByCategory(cargoBay);
            foreach (var item in ans)
            {
                Console.WriteLine($"{item.Key} have count of {item.Value}");
            }
            Console.WriteLine();

            //////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine();
            var flat = FlattenAndSortShipment(cargoBay);
            foreach (var f in flat)
            {
                Console.WriteLine($"{f.Category} {f.Name} {f.Weight}");
            }
        }
    }
}
