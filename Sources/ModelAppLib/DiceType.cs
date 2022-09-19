using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    internal class DiceType
    {
        private int NbDices;
        private Dice Prototype;

        public DiceType(int nbDices, Dice prototype)
        {
            NbDices = nbDices;
            Prototype = prototype;
        }
    }
}
