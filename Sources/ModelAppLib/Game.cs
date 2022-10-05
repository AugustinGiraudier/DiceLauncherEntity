using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ModelAppLib
{
    public class Game
    {

        private readonly List<DiceType> dices = new List<DiceType>();
        public ReadOnlyCollection<DiceType> Dices => dices.AsReadOnly(); 


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

        public bool AddDiceType(DiceType dt)
        {
            if (dices.Contains(dt))
            {
                dices.Find(x => x.Equals(dt))?.AddDice(dt.NbDices);
                return false;
            }
            dices.Add(dt);
            return true;
        }

        public List<DiceSide> LaunchDices()
        {
            var ret = new List<DiceSide>();
            IRandomizer rd = new SecureRandomizer();

            foreach (var dice in dices) // chaque type de dé
            {
                Dice d = dice.Prototype;
                for (int i=0; i<dice.NbDices; i++) // chaque dé
                {
                    ret.Add(d.GetSideWithItsIndex(rd.GetRandomInt(0,d.GetTotalSides())));
                }
            }

            return ret;
        }

    }
}
