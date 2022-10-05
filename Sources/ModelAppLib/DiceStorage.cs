using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ModelAppLib_UnitTests")]

namespace ModelAppLib
{
    internal class DiceStorage
    {
        private readonly List<Dice> dices;
        private readonly List<DiceSide> sides;

        /// <summary>
        /// retourne la liste des dés sous forme read only
        /// </summary>
        public ReadOnlyCollection<Dice> Dices => dices.AsReadOnly();
        /// <summary>
        /// retourne la liste des faces sous forme read only
        /// </summary>
        public ReadOnlyCollection<DiceSide> Sides => sides.AsReadOnly();

        /// <summary>
        /// Construit un stockage de dés et de faces
        /// </summary>
        /// <param name="dices">liste des dés (la liste sera clonée)</param>
        /// <param name="sides">liste des faces (la liste sera clonée)</param>
        public DiceStorage(List<Dice> dices, List<DiceSide> sides)
        {
            if(sides == null)
                this.sides = new List<DiceSide>();
            else
                this.sides = new List<DiceSide>(sides);
            if (dices == null)
                this.dices = new List<Dice>();
            else
                this.dices = new List<Dice>(dices);
        }

        public void AddDice(Dice d)
        {
            if(d!=null)
                dices.Add(d);
        }

        public void addSide(DiceSide ds)
        {
            if (ds != null)
                sides.Add(ds);
        }

        internal void InitDices(List<Dice> ld)
        {
            if (ld == null) return;
            dices.Clear();
            foreach (Dice d in ld)
            {
                dices.Add(d);
            }
        }

        internal void InitSides(List<DiceSide> lds)
        {
            if (lds == null) return;
            sides.Clear();
            foreach (DiceSide ds in lds)
            {
                sides.Add(ds);
            }
        }

    }
}
