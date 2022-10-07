using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelAppLib;

namespace EntitiesLib
{
    public class DataBaseLinker : IDataManager
    {
        private DiceLauncher_DbContext context = new DiceLauncher_DbContext();

        public async Task<bool> AddDice(Dice dice)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                var res = context.Dices.AddAsync(dice.ToEntity());
                context.SaveChanges();
            }
            return true;
        }

        public async Task<bool> AddGame(Game game)
        {
            //using (var context = new DiceLauncher_DbContext())
            {

                var res = context.Games.AddAsync(game.ToEntity());
                context.SaveChanges();
            }
            return true;
        }

        public async Task<bool> AddSide(DiceSide side)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                var res = await context.Sides.AddAsync(side.ToEntity());
                context.SaveChanges();
            }
            return true;
        }

        public async Task<List<Dice>> GetAllDices()
        {
            List<Dice> ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                var res = context.Dices;
                ret = res.ToModel();
            }
            return ret;
        }

        public async Task<List<Game>> GetAllGames()
        {
            List<Game> ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                ret = context.Games.ToModel();
            }
            return ret;
        }

        public async Task<List<DiceSide>> GetAllSides()
        {
            List<DiceSide> ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                ret = context.Sides.ToModel();
            }
            return ret;
        }

        public async Task<int> GetNbDice()
        {
            int ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                ret = context.Dices.Count();
            }
            return ret;
        }

        public async Task<int> GetNbGame()
        {
            int ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                ret = context.Games.Count();
            }
            return ret;
        }

        public async Task<int> GetNbSide()
        {
            int ret;
            //using (var context = new DiceLauncher_DbContext())
            {
                ret = context.Sides.Count();
            }
            return ret;
        }

        public async Task<List<Dice>> GetSomeDices(int nb, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Game>> GetSomeGames(int nb, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DiceSide>> GetSomeSides(int nb, int page)
        {
            throw new NotImplementedException();
        }

        ~DataBaseLinker()
        {
            this.context.Dispose();
        }
    }
}
