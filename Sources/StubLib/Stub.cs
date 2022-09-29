using System.Collections.Generic;
using System.Threading.Tasks;
using ModelAppLib;

namespace StubLib
{
    public class Stub : ILoader
    {
        public Task<List<Dice>> GetAllDices()
        {
            List<Dice> ret = new();

            var sides = GetAllSides().Result;

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

            return Task.FromResult(ret);
        }

        public Task<List<DiceSide>> GetAllSides()
        {
            List<DiceSide> ret = new();

            ret.Add(new DiceSide("1.png"));
            ret.Add(new DiceSide("2.png"));
            ret.Add(new DiceSide("3.png"));
            ret.Add(new DiceSide("4.png"));
            ret.Add(new DiceSide("5.png"));
            ret.Add(new DiceSide("6.png"));
            ret.Add(new DiceSide("star.png"));

            return Task.FromResult(ret);

        }

        public Task<List<Dice>> GetSomeDices(int nb, int page)
        {
            var sides = GetAllSides().Result;
            int cpt = 0;
            List<Dice> ret = new();
            for (int i = 0; i < nb; i++)
            {
                List<DiceSideType> lDst = new();
                for(int j=0; j<3; j++)
                {
                    lDst.Add(new DiceSideType(1, sides[cpt%7]));
                    cpt++;
                }
                ret.Add(new Dice(lDst));
            }

            return Task.FromResult(ret);
        }

        public Task<List<DiceSide>> GetSomeSides(int nb, int page)
        {
            List<DiceSide> ret = new();
            for (int i = nb * page; i < (nb * page) +nb; i++)
            {
                ret.Add(new DiceSide("img" + i));
            }

            return Task.FromResult(ret);
        }
    }
}
