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
            Figure s;

            while (true)
            {
                FigureFall(out s, generator);
                s.Draw();
            }

            Console.ReadLine();
        }

        static void FigureFall(out Figure fig, FigureGenerator generator)
        {
            fig = generator.GetNewFigure();
            fig.Draw();

            for (int i = 0; i < 15; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();
                Thread.Sleep(200);
            }
        }

    }
}
