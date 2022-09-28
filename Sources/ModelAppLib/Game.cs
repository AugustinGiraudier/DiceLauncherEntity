using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class Game
    {

        private readonly List<DiceType> dices;
        public ReadOnlyCollection<DiceType> Dices
        {
            get { return dices.AsReadOnly(); }
        }
        /// Apparemment, c'est mieux de mettre des trucs comme ca: public System.Collections.ObjectModel.ReadOnlyCollection<Nounours> NounoursROC2 => mNounours.AsReadOnly();
        /// Ca vient de la doc de Chevaldonne, parce qu'il a dit qu'on avait pas vue la doc avant de faire ca 


        public Game(List<DiceType> dices)
        {
            if(dices == null)
                this.dices = new List<DiceType>();
            else
                this.dices = new List<DiceType>(dices);
        }
        public Game(params DiceType[] dices)
        {
            foreach(var dice in dices)
            {
                AddDiceType(dice);
            }
        }

        public void AddDiceType(DiceType dt)
        {
            if (dices.Contains(dt))
                dices.Find(x => x.Equals(dt)).AddDice(dt.NbDices);
            else
                dices.Add(dt);
        }

        public List<DiceSide> LaunchDices()
        {
            var ret = new List<DiceSide>();
            var rd = new Random();

            foreach (var dice in dices) // chaque type de dé
            {
                Dice d = dice.Prototype;
                for (int i=0; i<dice.NbDices; i++) // chaque dé
                {
                    ret.Add(d.GetSideWithItsIndex(rd.Next(d.GetTotalSides())));
                }
            }

            return ret;
        }

    }
}
