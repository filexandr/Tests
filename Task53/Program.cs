using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task53
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "green", "brown", "blue", "red" };
            string s = "e";
            var query = colors.Where(c => c.Contains(s));
            s = "n";
            query = query.Where(c => c.Contains(s));

            Console.WriteLine(query.Count());
            Console.ReadLine();
        }
    }
}
