using System.Collections.Generic;
using ModelAppLib;

namespace StubLib
{
    internal class Stub : Loader
    {
        public List<Dice> GetAllDices()
        {
            List<Dice> ret = new();

            var sides = GetAllSides();

            ret.Add(new Dice(
                new DiceSideType(1, sides[0]),
                new DiceSideType(1, sides[1]),
                new DiceSideType(1, sides[2]),
                new DiceSideType(1, sides[3]),
                new DiceSideType(1, sides[4]),
                new DiceSideType(1, sides[5])));

            ret.Add(new Dice(
                new DiceSideType(2, sides[2]), 
                new DiceSideType(3, sides[0])));

            ret.Add(new Dice(
                new DiceSideType(1, sides[0]),
                new DiceSideType(2, sides[1]),
                new DiceSideType(3, sides[2])));

            ret.Add(new Dice(
                new DiceSideType(5, sides[5]),
                new DiceSideType(1, sides[6])));

            return ret;
        }

        public List<DiceSide> GetAllSides()
        {
            List<DiceSide> ret = new();

            ret.Add(new DiceSide("1.png"));
            ret.Add(new DiceSide("2.png"));
            ret.Add(new DiceSide("3.png"));
            ret.Add(new DiceSide("4.png"));
            ret.Add(new DiceSide("5.png"));
            ret.Add(new DiceSide("6.png"));
            ret.Add(new DiceSide("star.png"));

            return ret;

        }
    }
}
