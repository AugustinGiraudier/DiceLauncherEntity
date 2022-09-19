using System;
using System.Collections.Generic;
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
        public int NbDices
        {
            get
            {
                return NbDices;
            }
            set
            {
                NbDices = value;
            }
        }

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
    }
}
