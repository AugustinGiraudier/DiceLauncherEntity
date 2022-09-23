using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class DiceType
    {
        /// <summary>
        /// Nombre de dé de ce type
        /// </summary>
        public int NbDices { get; private set; }

        private Dice Prototype;

        /// <summary>
        /// Construit un type de dé avec un dé et une quantité
        /// </summary>
        /// <param name="nbDices">Nombre de dé de ce type</param>
        /// <param name="prototype">Dé cible</param>
        public DiceType(int nbDices, Dice prototype)
        {
            NbDices = nbDices;
            Prototype = prototype;
        }

        /// <summary>
        /// Egaux si même nombre de dé et même prototype
        /// </summary>
        /// <param name="obj">objet à comparer</param>
        /// <returns>true si égaux false sinon</returns>
        public override bool Equals(object obj)
        {
            DiceType ds = obj as DiceType;
            if (ds != null)
                return (this.NbDices == ds.NbDices && this.Prototype.Equals(ds.Prototype));
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
