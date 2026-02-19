namespace GraphSocialNetwork
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> friends = new List<Person>();
        public Person(string name) => Name = name;

        //public void AddFriends(Person friend)
        //{
        //    if (!friends.Contains(friend))
        //    {
        //        friends.Add(friend);
        //        friend.friends.Add(this);
        //    }
        //}

        //public void RemoveFriend(Person friend)
        //{
        //    if (friends.Contains(friend))
        //    {
        //        friends.Remove(friend);
        //        friend.friends.Remove(this);
        //    }
        //}
    }

    class SocialNetwork
    {
        List<Person> _members = new List<Person>();
        public void AddMembers(Person member)
        {
            _members.Add(member);
        }

        public void AddFriends(Person friend1, Person friend2)
        {
            if (!_members.Contains(friend1) || !_members.Contains(friend2))
            {
                Console.WriteLine($"Members {friend1.Name} {friend2.Name} is not on Social Site");
            }

            else
            {
                if (!friend1.friends.Contains(friend2))
                {
                    friend1.friends.Add(friend2);
                    friend2.friends.Add(friend1);
                }

            }
        }

        public void ShowNetwork()
        {
            foreach (Person member in _members)
            {
                Console.Write(member.Name + " -> ");
                List<string> fri = new List<string>();
                foreach (Person friend in member.friends)
                {
                    fri.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",", fri)}");
            }
        }
    }
    internal class SocialMedia
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            Person aman = new Person("Aman");
            Person bhaskar = new Person("Bhaskar");
            Person chetan = new Person("Chetan");
            Person divakar = new Person("Divakar");
            Person Jai = new Person("Jai");

            network.AddMembers(aman);
            network.AddMembers(bhaskar);
            network.AddMembers(chetan);
            network.AddMembers(divakar);

            //aman.AddFriends(bhaskar);
            //aman.AddFriends(chetan);
            ////aman.AddFriends(divakar);
            //bhaskar.AddFriends(chetan);
            //divakar.AddFriends(Jai);
            //chetan.RemoveFriend(aman);

            network.AddFriends(aman, bhaskar);
            network.AddFriends(aman, chetan);
            network.AddFriends(aman, bhaskar);
            network.AddFriends(chetan, divakar);
            network.AddFriends(chetan, bhaskar);
            network.AddFriends(Jai, aman);


            network.ShowNetwork();
        }
    }
}
