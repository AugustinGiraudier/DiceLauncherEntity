using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    internal class DiceSideType
    {
        private int NbSide;
        private DiceSide Prototype;

        public DiceSideType(int nbSide, DiceSide prototype)
        {
            NbSide = nbSide;
            Prototype = prototype;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj is DiceSideType)
                return this.Prototype == ((DiceSideType)obj).Prototype;
            return false;
        }
    }
}
