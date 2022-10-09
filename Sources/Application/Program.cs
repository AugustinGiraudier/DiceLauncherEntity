using EntitiesLib;
using ModelAppLib;
using NLog;
using System;
using System.Collections.Generic;

namespace ModelApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            LogManager.Setup().LoadConfiguration(builder => {
                builder.ForLogger().FilterMinLevel(LogLevel.Trace).WriteToConsole();
            });


            ModelManager manager = new ModelManager(new DataBaseLinker());

            {

                var sides = manager.GetAllSides();

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
                manager.AddDice(d);

                var dices = manager.GetAllDices();
                var dt = new DiceType(2, dices[0]);

                var g = new Game(dt);
                manager.AddGame(g);


                var games = manager.GetAllGames();

                foreach(var side in games[0].LaunchDices())
                {
                    Console.WriteLine(side.Image);
                }


            }
        }
    }
}
