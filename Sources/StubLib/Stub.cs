using System.Collections.Generic;
using System.Threading.Tasks;
using ModelAppLib;

namespace StubLib
{
    public class Stub : IDataManager
    {
        public Task<bool> AddDice(Dice dice)
        {
            return Task.FromResult(true);
        }

        public Task<bool> AddGame(Game game)
        {
            return Task.FromResult(true);
        }

        public Task<bool> AddSide(DiceSide side)
        {
            return Task.FromResult(true);
        }

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

        public Task<List<Game>> GetAllGames()
        {
            List<Game> ret = new();

            var dices = GetAllDices().Result;

            ret.Add(new Game(new List<DiceType> {
                new DiceType(1, dices[0]),
                new DiceType(2, dices[1]),
                new DiceType(3, dices[2])
            }));
            
            ret.Add(new Game(new List<DiceType> {
                new DiceType(5, dices[0])
            }));

            ret.Add(new Game(new List<DiceType> {
                new DiceType(1, dices[0]),
                new DiceType(1, dices[1]),
                new DiceType(1, dices[2]),
                new DiceType(1, dices[3])
            }));

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

        public Task<int> GetNbDice()
        {
            return Task.FromResult(GetAllDices().Result.Count);
        }

        public Task<int> GetNbGame()
        {
            return Task.FromResult(GetAllGames().Result.Count);
        }

        public Task<int> GetNbSide()
        {
            return Task.FromResult(GetAllSides().Result.Count);
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

        public Task<List<Game>> GetSomeGames(int nb, int page)
        {
            List<Game> games = GetAllGames().Result;
            List<Game> ret = new();
            for (int i = nb * page; i < (nb * page) + nb; i++)
            {
                ret.Add(games[i%games.Count]);
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
