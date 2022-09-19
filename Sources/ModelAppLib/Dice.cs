using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    internal class Dice
    {

        private List<DiceSideType> SidesTypes;

        public void addSide(DiceSideType sideT)
        {
            if (SidesTypes.Contains(sideT))
            {
                // add number of dice (require getter & setters on DiceSideType.Nb)
            }
            else
            {
                SidesTypes.Add(sideT);
            }
        }

    }
}
