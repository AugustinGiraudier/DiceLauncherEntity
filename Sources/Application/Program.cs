using System;
using ModelAppLib;
using NLog;

namespace ModelApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            LogManager.Setup().LoadConfiguration(builder => {
                builder.ForLogger().FilterMinLevel(LogLevel.Trace).WriteToConsole();
            });

            Dice d = new(new DiceSideType(3, new DiceSide("img1")));
            d.GetTotalSides();

        }
    }
}
