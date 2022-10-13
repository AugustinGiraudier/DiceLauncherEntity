﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelAppLib;

namespace EntitiesLib
{
    public class DataBaseLinker : IDataManager
    {
        protected readonly DiceLauncherDbContext context;

        /// <summary>
        /// Create a db linker with existing context. It will be disposed at the end
        /// </summary>
        /// <param name="context"></param>
        public DataBaseLinker(DiceLauncherDbContext context)
        {
            this.context = context;
        }
        public DataBaseLinker()
        {
            this.context = new DiceLauncherDbContext();
        }




        // ===================================================== //
        //      = CREATE =
        // ===================================================== //


        public async Task<bool> AddDice(Dice dice)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                var entity = dice.ToEntity(context);
                await context.Dices.AddAsync(entity);
                await context.SaveChangesAsync();
                dice.Id = entity.Id;
                return true;
            }
        }
        public async Task<bool> AddGame(Game game)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                var entity = game.ToEntity(context);
                await context.Games.AddAsync(entity);
                await context.SaveChangesAsync();
                game.Id = entity.Id;
                return true;
            }
        }
        public async Task<bool> AddSide(DiceSide side)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                var entity = side.ToEntity();
                await context.Sides.AddAsync(entity);
                await context.SaveChangesAsync();
                side.Id = entity.Id;
                return true; 
            }
        }


        // ===================================================== //
        //      = REMOVE =
        // ===================================================== //
        

        public async Task<bool> DeleteDice(Dice d)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                context.Dices.Remove(GetDiceEntity(d));
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteGame(Game g)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                context.Games.Remove(GetGameEntity(g));
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteSide(DiceSide ds)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                context.Sides.Remove(GetSideEntity(ds));
                await context.SaveChangesAsync();
                return true;
            }
        }


        // ===================================================== //
        //      = SELECT =
        // ===================================================== //


        public Task<IEnumerable<Dice>> GetAllDices()
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(
                       context.Dices.Include(d => d.Sides)
                                    .ThenInclude(s => s.Prototype)
                                    .ToModel()
                                    );
            }
        }
        public Task<IEnumerable<Game>> GetAllGames()
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult( 
                    context.Games.Include(g => g.DiceTypes)
                                 .ThenInclude(d => d.Prototype)
                                 .ToModel()
                                 );
            }
        }
        public Task<IEnumerable<DiceSide>> GetAllSides()
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(context.Sides.ToModel());
            }
        }
        public Task<IEnumerable<Dice>> GetSomeDices(int nb, int page)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(
                          context.Dices.Include(d => d.Sides)
                                       .ThenInclude(s => s.Prototype)
                                       .Skip(nb * page)
                                       .Take(nb)
                                       .ToModel()
                                       );
            }
        }
        public Task<IEnumerable<Game>> GetSomeGames(int nb, int page)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(
                          context.Games.Include(g => g.DiceTypes)
                                       .ThenInclude(d => d.Prototype)
                                       .Skip(nb * page)
                                       .Take(nb)
                                       .ToModel()
                                       );
            }
        }
        public Task<IEnumerable<DiceSide>> GetSomeSides(int nb, int page)
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(
                    context.Sides.Skip(nb * page).Take(nb)
                                 .ToModel()
                    ) ;
            }
        }


        // ===================================================== //
        //      = COUNT =
        // ===================================================== //


        public Task<int> GetNbDice()
        {

            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(context.Dices.Count());
            }
        }

        public Task<int> GetNbGame()
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(context.Games.Count());
            }
        }

        public Task<int> GetNbSide()
        {
            //using (var context = new DiceLauncher_DbContext())
            {
                return Task.FromResult(context.Sides.Count());
            }
        }


        // ===================================================== //
        //      = PRIVATE =
        // ===================================================== //


        /// <summary>
        /// Retourne l'entité de dé correspondant au dé
        /// </summary>
        /// <param name="d">dé</param>
        /// <returns></returns>
        private DiceEntity GetDiceEntity(Dice d)
        {
            return context.Dices.First(d2 => d2.Id == d.Id);
        }

        /// <summary>
        /// Retourne l'entité de face correspondant à la face
        /// </summary>
        /// <param name="ds">face</param>
        /// <returns></returns>
        private DiceSideEntity GetSideEntity(DiceSide ds)
        {
            return context.Sides.First(d2 => d2.Id == ds.Id);
        }

        /// <summary>
        /// Retourne l'entité de partie correspondant à la partie
        /// </summary>
        /// <param name="g">partie</param>
        /// <returns></returns>
        private GameEntity GetGameEntity(Game g)
        {
            return context.Games.First(g2 => g2.Id == g.Id);
        }

    }
}
