using EntitiesLib;
using StubLib;

namespace StubEntitiesLib
{
    public class StubedDatabaseLinker : DataBaseLinker
    {

        public StubedDatabaseLinker(DiceLauncherDbContext context)
            :base(context)
        {
            var stub = new Stub();
            var sides = stub.GetAllSides().Result;
            foreach(var side in sides)
                this.context.Sides.Add(side.ToEntity());
            context.SaveChanges();
        }

    }
}
