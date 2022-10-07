using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelAppLib;

namespace EntitiesLib
{
    public class DataBaseLinker : IDataManager
    {
        
        public Task<bool> AddDice(Dice dice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSide(DiceSide side)
        {
            using (var context = new DiceLauncher_DbContext())
            {
                var r = await context.DiceSides.AddAsync(side.ToEntity());

                if (r.State != Microsoft.EntityFrameworkCore.EntityState.Added)
                    return false;

                context.SaveChanges();
            }
            return true;
        }

        public Task<List<Dice>> GetAllDices()
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public async Task<List<DiceSide>> GetAllSides()
        {
            List<DiceSide> ret;
            using(var context = new DiceLauncher_DbContext())
            {
                ret = context.DiceSides.ToModel();
            }
            return ret;
        }

        public Task<int> GetNbDice()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbGame()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbSide()
        {
            throw new NotImplementedException();
        }

        public Task<List<Dice>> GetSomeDices(int nb, int page)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetSomeGames(int nb, int page)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiceSide>> GetSomeSides(int nb, int page)
        {
            throw new NotImplementedException();
        }
    }
}
