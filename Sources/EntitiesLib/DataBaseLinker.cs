using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelAppLib;

namespace EntitiesLib
{
    public class DataBaseLinker : IDataManager
    {
        private DiceLauncher_DbContext context = new DiceLauncher_DbContext();

        public async Task<bool> AddDice(Dice dice)
        {
            await context.Dices.AddAsync(dice.ToEntity(context));
            context.SaveChanges();
            return true;
        }

        public async Task<bool> AddGame(Game game)
        {
            await context.Games.AddAsync(game.ToEntity(context));
            context.SaveChanges();
            return true;
        }

        public async Task<bool> AddSide(DiceSide side)
        {
            await context.Sides.AddAsync(side.ToEntity());
            context.SaveChanges();
            return true;
        }

        public async Task<List<Dice>> GetAllDices()
        {
            return context.Dices.Include(d => d.Sides).ThenInclude(s => s.Prototype).ToModel();
        }

        public async Task<List<Game>> GetAllGames()
        {
            return context.Games.Include(g => g.DiceTypes).ThenInclude(d => d.Prototype).ToModel();
        }

        public async Task<List<DiceSide>> GetAllSides()
        {
            return context.Sides.ToModel();
        }

        public async Task<int> GetNbDice()
        {
            return context.Dices.Count();
        }

        public async Task<int> GetNbGame()
        {
            return context.Games.Count();
        }

        public async Task<int> GetNbSide()
        {
            return context.Sides.Count();
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
