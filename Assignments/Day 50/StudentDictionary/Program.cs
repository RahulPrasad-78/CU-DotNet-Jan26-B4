namespace StudentDictionary
{
    class Student
    {
        public int StuId { get; set; }
        public string SName { get; set; }

        public Student(int id, string name)
        {
            StuId = id;
            SName = name;
        }

        public override bool Equals(object? obj)
        {
            Student temp = obj as Student;
            return this.StuId == temp.StuId && this.SName == temp.SName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StuId, SName);
        }
    }

    class Management
    {
        static Dictionary<Student, int> StudRecord = new Dictionary<Student, int>();

        public static void AddStud(Student s, int marks)
        {
            if (!StudRecord.ContainsKey(s))
            {
                StudRecord.Add(s, marks);
            }
            else if (marks > StudRecord[s])
            {
                StudRecord[s] = marks;
            }
        }

        public static void Display()
        {
            foreach (var stud in StudRecord)
            {
                Console.WriteLine($"Name : {stud.Key.SName}   Marks : {stud.Value}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(21, "Rahul");
            Management.AddStud(s1, 56);

            Student s2 = new Student(34, "Jai");
            Management.AddStud(s2, 80);

            Student s3 = new Student(31, "Sneha");
            Management.AddStud(s3, 90);

            Student s4 = new Student(31, "Sneha");
            Management.AddStud(s4, 100);

            Management.Display();
        }
    }
}