using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class VowelsShiftClipper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string str = Console.ReadLine().ToLower();

            Dictionary<char, char> d = new Dictionary<char, char>()
            {
                {'a', 'e'},
                {'e', 'i'},
                {'i', 'o'},
                {'o', 'u'},
                {'u', 'a'}
            };
            string ans = string.Empty;
            for(int i=0; i<str.Length; i++)
            {
                char ch = str[i];
                //Console.Write(str[i] + " - ");
                if (d.ContainsKey(ch))    ans += d[ch];
                else
                {

                    ch = (char)('a' + (ch - 'a' + 1) % 26);
                    if (d.ContainsKey(ch)) ch++;
                    ans += ch;
                }
               
            }
            Console.WriteLine(ans);
        }
    }
}
