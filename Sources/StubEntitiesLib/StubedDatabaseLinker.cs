using EntitiesLib;
using StubLib;
using System.Linq;

namespace StubEntitiesLib
{
    public class StubedDatabaseLinker : DataBaseLinker
    {

        public StubedDatabaseLinker(DiceLauncherDbContext context)
            :base(context)
        {
            StubThisLinker();
        }
        
        public StubedDatabaseLinker()
            :base()
        {
            StubThisLinker();
        }

        private void StubThisLinker()
        {
            if(!context.Sides.Any())
            {
                var stub = new Stub();
                var sides = stub.GetAllSides().Result;
                foreach (var side in sides)
                    this.context.Sides.Add(side.ToEntity());
                context.SaveChanges();
            }
        }



    }
}
