﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris
{
    internal class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();


        static Figure currentFigure;
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();


            //Field.Width = 20;


            generator = new FigureGenerator(Field.Width/2,0);
            currentFigure = generator.GetNewFigure();
            SetTimer();

/*            var i = 1; // int i = 1;
            var s = "привет"; // string s = "привет";*/

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }

            //Console.ReadLine();
        }

        private static void Test()
        {
            DrawerProvider.Drawer.DrawPoint(5, 6);
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(TIMER_INTERVAL);

            // Hook upe the Elapsed event for the timer.
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if(currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }


                currentFigure = generator.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static Result HandleKey(Figure f, ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return f.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return f.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return f.TryRotate();
            }

            return Result.SUCCESS;
        }
    }
}
