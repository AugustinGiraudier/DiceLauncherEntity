using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class Dice
    {

        private List<DiceSideType> SidesTypes = new List<DiceSideType>();

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
        /// Construit un dé avec ses types de faces
        /// </summary>
        /// <param name="sidesTypes">Liste des types de faces qui sera clonnée</param>
        public Dice(List<DiceSideType> sidesTypes)
        {
            SidesTypes = new List<DiceSideType>(sidesTypes);
        }

        /// <summary>
        /// Ajoute un type de face au dé (additionne le nombre de face si déja existante)
        /// </summary>
        /// <param name="sideT">Type de face à ajouter</param>
        public void addSide(DiceSideType sideT)
        {
            if (SidesTypes.Contains(sideT))
                SidesTypes.Find(x => x.Equals(sideT)).AddSides(sideT.NbSide);
            else
                SidesTypes.Add(sideT);
        }

    }
}
