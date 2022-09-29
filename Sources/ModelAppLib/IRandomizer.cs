using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    internal interface IRandomizer
    {
        public int GetRandomInt(int min, int max);
    }
}
