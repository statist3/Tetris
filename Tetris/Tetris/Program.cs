﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20,0, '*');
            Figure currentFigure = generator.GetNewFigure();

/*            var i = 1; // int i = 1;
            var s = "привет"; // string s = "привет";*/

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(currentFigure, key);
                }
            }

            Console.ReadLine();
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.Move(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.Move(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.Move(Direction.DOWN);
                    break;
            }
        }
    }
}
