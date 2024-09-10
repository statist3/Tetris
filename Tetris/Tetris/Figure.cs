﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGTH = 4;
        public Point[] Points = new Point[LENGTH];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }



        internal Result TryMove(Direction dir)
        {
            Hide();

            Move(dir);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(dir));

            Draw();

            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch(dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;
            }

            return Direction.RIGHT;
        }

        private void Move(Direction dir)
        {
            foreach(var p in Points)
            {
                p.Move(dir);
            }
        }

        internal Result TryRotate()
        {
            Hide();
            Rotate();

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Rotate();

            Draw();
            return result;
        }

        public abstract void Rotate();

        private Result VerifyPosition()
        {
            foreach(var p in Points)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.ChechStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }

        public void Move(Point[] pList, Direction dir)
        {
            foreach(var p in pList)
            {
                p.Move(dir);
            }
        }


        //private Point[] Clone()
        //{
        //    var newPoints = new Point[LENGTH];
        //    for(int i = 0; i < LENGTH; i++)
        //    {
        //        newPoints[i] = new Point(Points[i]);
        //    }
        //    return newPoints;
        //}


        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }


        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }
    }
}
