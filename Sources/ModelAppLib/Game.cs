﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModelAppLib
{
    /// <summary>
    /// Classe modélisant une partie avec ses dés et la possibilité de simuler leur lancer
    /// </summary>
    public class Game
    {
        public long Id { get; set; }
        private readonly List<DiceType> dices = new List<DiceType>();
        public ReadOnlyCollection<DiceType> Dices => dices.AsReadOnly(); 


        public Game(IEnumerable<DiceType> dices)
        {
            if(dices == null)
                throw new ArgumentNullException(nameof(dices), "la liste de dés ne peut etre null");
            
            foreach (var dice in dices)
            {
                if (dice == null)
                    throw new ArgumentNullException(nameof(dices), "un des dés est null");
                AddDiceType(dice);
            }
        }
        public Game(params DiceType[] dices)
            :this(dices.AsEnumerable())
        {
        }

        /// <summary>
        /// Ajoute un type de dé au jeu
        /// </summary>
        /// <param name="dt">type de dé à ajouter</param>
        /// <returns></returns>
        public bool AddDiceType(DiceType dt)
        {
            if(dt == null)
                throw new ArgumentNullException(nameof(dt), "le type de dé ne peut etre null");
            if (dices.Contains(dt))
            {
                dices.Find(x => x.Equals(dt))?.AddDice(dt.NbDices);
                return false;
            }
            dices.Add(dt);
            return true;
        }

        /// <summary>
        /// Génère un lancé des dés de la partie
        /// </summary>
        /// <returns>la liste des faces résultat</returns>
        public IEnumerable<DiceSide> LaunchDices()
        {
            var ret = new List<DiceSide>();

            foreach (var dice in dices) // chaque type de dé
            {
                Dice d = dice.Prototype;
                for (int i=0; i<dice.NbDices; i++) // chaque dé
                {
                    ret.Add(d.GetRandomSide());
                }
            }

            return ret;
        }

    }
}
