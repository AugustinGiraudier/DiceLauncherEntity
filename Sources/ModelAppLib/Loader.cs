using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public interface Loader
    {

        public List<Dice> GetAllDices();
        public List<DiceSide> GetAllSides();


    }
}
