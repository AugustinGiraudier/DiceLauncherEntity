using EntitiesLib;
using ModelAppLib;
using NLog;
using System;

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
                var ds1 = new DiceSide("1.png");
                var ds2 = new DiceSide("2.png");
                var ds3 = new DiceSide("3.png");

                //manager.dataManager.AddSide(ds1);
                //manager.dataManager.AddSide(ds2);
                //manager.dataManager.AddSide(ds3);

                //var sides = manager.GetAllSides();

                var dst1 = new DiceSideType(1, ds1);
                var dst2 = new DiceSideType(1, ds2);

                var d = new Dice(dst1, dst2);

                //var dices = manager.GetAllDices();
                var dt = new DiceType(2, d);

                var g = new Game(dt);
                manager.AddGame(g);
            }
            {
                var ds1 = new DiceSide("1.png");
                var ds2 = new DiceSide("2.png");
                var ds3 = new DiceSide("3.png");

                var dst1 = new DiceSideType(1, ds1);
                var dst2 = new DiceSideType(1, ds2);

                var d = new Dice(dst1, dst2);

                var dt = new DiceType(2, d);

                var g = new Game(dt);
                manager.AddGame(g);
            }
        }
    }
}
