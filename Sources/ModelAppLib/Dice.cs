using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    internal class Dice
    {

        private List<DiceSideType> SidesTypes;

        /// <summary>
        /// Retourne la liste de types de faces sous forme read only
        /// </summary>
        public ReadOnlyCollection<DiceSideType> GetSideTypes
        {
            get
            {
                return SidesTypes.AsReadOnly();
            }
        }

        /// <summary>
        /// Ajoute un type de face au dé (additionne le nombre de face si déja existante)
        /// </summary>
        /// <param name="sideT">Type de face à ajouter</param>
        public void addSide(DiceSideType sideT)
        {
            if (SidesTypes.Contains(sideT))
                SidesTypes.Find(x => x == sideT).NbSide += sideT.NbSide;
            else
                SidesTypes.Add(sideT);
        }

    }
}
