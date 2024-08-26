using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimor
{
    class Officer : Humans
    {
        public string rank;

        public Officer(int a, string r)
        {
            age = a;
            rank = r;
        }


        public override void Write()
        {
            Console.WriteLine($"age: {age}. height: {height}. rank: {rank}");
        }
    }
}
