using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class DiceSideType
    {
        /// <summary>
        /// Nombre de face de ce type
        /// </summary>
        public int NbSide { get; private set; }

        private DiceSide Prototype;

        /// <summary>
        /// Construit un type de face avec un prototype et une quantité
        /// </summary>
        /// <param name="nbSide">Nombre d'occurence de ce type de face</param>
        /// <param name="prototype">Type de face</param>
        public DiceSideType(int nbSide, DiceSide prototype)
        {
            NbSide = nbSide;
            Prototype = prototype;
        }

        public void AddSides(int nbToAdd)
        {
            NbSide += nbToAdd;
        }

        
        public override bool Equals(object obj)
        {
            if (obj is DiceSideType)
                return this.Prototype == ((DiceSideType)obj).Prototype;
            return false;
        }
    }
}
