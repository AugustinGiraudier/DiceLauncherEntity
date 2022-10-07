using System;
using System.Collections.Generic;
using EntitiesLib;
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


            ModelManager manager = new ModelManager(new DataBaseLinker());
            

            List<DiceSide> sides = manager.dataManager.GetAllSides().Result;

            foreach (var side in sides)
            {
                Console.WriteLine(side.Image);
            }


        }
    }
}
