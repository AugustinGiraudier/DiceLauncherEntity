using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ModelAppLib_UnitTests")]
[assembly: InternalsVisibleTo("StubLib")]

namespace ModelAppLib
{
    internal interface ILoader
    {

        public Task<List<Dice>> GetAllDices();
        public Task<List<DiceSide>> GetAllSides();

        public Task<List<Dice>> GetSomeDices(int nb, int page);
        public Task<List<DiceSide>> GetSomeSides(int nb, int page);

    }
}
