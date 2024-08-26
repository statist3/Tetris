using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Humans[] humans = new Humans[2];
            humans[0] = new Employee(12, 100000);
            humans[1] = new Officer(30, "Подполковник");


            foreach(Humans h in humans)
            {
                h.Write();
            }

            Console.ReadLine();
        }
    }
}
