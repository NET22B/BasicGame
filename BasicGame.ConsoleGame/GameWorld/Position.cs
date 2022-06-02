using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGame.ConsoleGame.GameWorld
{
    //public struct Position
    //{
    //    public int Y { get; }
    //    public int X { get; }

    //    public Position(int y, int x)
    //    {
    //        Y = y;
    //        X = x;
    //    }

    //    public static Position operator +(Position p1, Position p2) => new Position(p1.Y + p2.Y, p1.X + p2.X);
    //} 
    public record Demo(int X, string Y, string[] items);
    //{
    //    public int Y { get; init; }
    //    public int X { get; init; }

    //    public Demo(int y, int x)
    //    {
    //        Y = y;
    //        X = x;
    //    }

    //}

    public record Position(int Y, int X)
    {
        public static Position operator +(Position p1, Position p2) => new Position(p1.Y + p2.Y, p1.X + p2.X);
    }
}
