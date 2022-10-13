using EntitiesLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ModelAppLib;
using StubEntitiesLib;
using System.Linq;
using Xunit;

namespace Entities_UnitTests
{
    public class UT_DataBaseLinker
    {

        [Fact]
        async void TestAddingDice()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DiceLauncherDbContext>()
                .UseSqlite(connection)
                .Options;

            var context = new DiceLauncherDbContext(options);
            context.Database.EnsureCreated();
            StubedDatabaseLinker linker = new StubedDatabaseLinker(context);

            var sides = linker.GetAllSides().Result.ToList();

            await linker.AddDice(new Dice(new DiceSideType(2, sides[0])));

            Assert.Single(linker.GetAllDices().Result);
            Assert.Equal(1, linker.GetNbDice().Result);

        }

    }
}
