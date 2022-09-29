using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public interface ILoader
    {

        public Task<List<Dice>> GetAllDices();
        public Task<List<DiceSide>> GetAllSides();

        public Task<List<Dice>> GetSomeDices(int nb, int page);
        public Task<List<DiceSide>> GetSomeSides(int nb, int page);

    }
}
