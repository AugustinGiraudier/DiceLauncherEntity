using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class DiceStorage
    {
        private List<Dice> Dices;
        private List<DiceSide> Sides;

        /// <summary>
        /// retourne la liste des dés sous forme read only
        /// </summary>
        public ReadOnlyCollection<Dice> GetDices 
        { 
            get { return Dices.AsReadOnly(); } 
        }
        /// <summary>
        /// retourne la liste des faces sous forme read only
        /// </summary>
        public ReadOnlyCollection<DiceSide> GetSides
        {
            get { return Sides.AsReadOnly(); }
        }

        /// <summary>
        /// Construit un stockage de dés et de faces
        /// </summary>
        /// <param name="dices">liste des dés (la liste sera clonée)</param>
        /// <param name="sides">liste des faces (la liste sera clonée)</param>
        public DiceStorage(List<Dice> dices, List<DiceSide> sides)
        {
            this.Sides = new List<DiceSide>(sides);
            this.Dices = new List<Dice>(dices);
        }


    }
}
