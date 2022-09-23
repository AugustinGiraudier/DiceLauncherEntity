using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class Dice
    {

        private List<DiceSideType> sidesTypes = new List<DiceSideType>();

        /// <summary>
        /// Retourne la liste de types de faces sous forme read only
        /// </summary>
        public ReadOnlyCollection<DiceSideType> SideTypes
        {
            get
            {
                return sidesTypes.AsReadOnly();
            }
        }

        /// <summary>
        /// Construit un dé avec la liste de ses types de faces
        /// </summary>
        /// <param name="sidesTypes">Liste des types de faces qui sera clonnée</param>
        public Dice(List<DiceSideType> sidesTypes)
        {
            this.sidesTypes = new List<DiceSideType>();
            foreach (DiceSideType dst in sidesTypes)
                this.addSide(dst);
        }
        /// <summary>
        /// Construit un dé avec ses types de faces en parametre
        /// </summary>
        /// <param name="dstypes">types de face du dé</param>
        public Dice(params DiceSideType[] dstypes)
        {
            this.sidesTypes = new List<DiceSideType>();
            foreach(DiceSideType dst in dstypes)
                this.addSide(dst);
        }

        /// <summary>
        /// Ajoute un type de face au dé (additionne le nombre de face si déja existante)
        /// </summary>
        /// <param name="sideT">Type de face à ajouter</param>
        public void addSide(DiceSideType sideT)
        {
            if (sidesTypes.Contains(sideT))
                sidesTypes.Find(x => x.Equals(sideT)).AddSides(sideT.NbSide);
            else
                sidesTypes.Add(sideT);
        }

        /// <summary>
        /// Egaux si mêmes types de faces
        /// </summary>
        /// <param name="obj">objet à comparer</param>
        /// <returns>true si égaux false sinon</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Dice d = obj as Dice;
            if (d != null)
                return this.SideTypes.SequenceEqual(d.SideTypes);
            return false;
        }

        public override int GetHashCode()
        {
            return this.SideTypes.GetHashCode();
        }
    }
}
