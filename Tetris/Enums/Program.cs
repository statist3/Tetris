﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day day = Day.Mon;
            int i = 3;

            Day day3 = (Day)i;
            Console.WriteLine(day3);

            if(day == Day.Mon)
            {
                Console.WriteLine("Понедельник");
                Console.WriteLine((int)day);
            }
        }
    }
}
