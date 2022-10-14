using EntitiesLib;
using ModelAppLib;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelApp
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            LogManager.Setup().LoadConfiguration(builder => {
                builder.ForLogger().FilterMinLevel(LogLevel.Trace).WriteToConsole();
            });


            ModelManager manager = new ModelManager(new DataBaseLinker());

            var sides = (await manager.GetAllSides()).ToList();

            var sideTypes = new List<DiceSideType>
            {
                new DiceSideType(1, sides[0]),
                new DiceSideType(1, sides[1]),
                new DiceSideType(1, sides[5]),
                new DiceSideType(1, sides[3]),
                new DiceSideType(1, sides[2]),
                new DiceSideType(1, sides[4]),
                new DiceSideType(2, sides[6])
            };

            var d = new Dice(sideTypes);
            await manager.AddDice(d);

            var dt = new DiceType(2, d);

            var g = new Game(dt);
            await manager.AddGame(g);

            foreach(var side in g.LaunchDices())
            {
                Console.WriteLine(side.Image);
            }

            await manager.RemoveGame(g);
            await manager.RemoveDice(d);

        }
    }
}
