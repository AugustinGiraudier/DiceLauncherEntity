using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelAppLib
{
    public class ModelManager
    {

        private DiceStorage diceStorage = new DiceStorage(null, null);
        private List<Game> games = new List<Game>();

        /// <summary>
        /// Ajoute un dé au stockage
        /// </summary>
        /// <param name="d">dé à ajouter</param>
        public void AddDice(Dice d) 
        {
            diceStorage.AddDice(d);
        }
        /// <summary>
        /// Ajoute une partie au stockage
        /// </summary>
        /// <param name="g">partie à ajouter</param>
        public void AddGame(Game g)
        {
            if(g != null)
                games.Add(g);
        }

        /// <summary>
        /// Retourne le nombre de dés du stockage
        /// </summary>
        /// <returns>le nombre de dés</returns>
        public int GetDiceCount() { return diceStorage.Dices.Count; }

        /// <summary>
        /// Retourne le nombre de faces de dé du stockage
        /// </summary>
        /// <returns>le nombre de faces</returns>
        public int GetSideCount() { return diceStorage.Sides.Count; }

        /// <summary>
        /// Retourne le nombre de parties du stockage
        /// </summary>
        /// <returns>nombre de parties</returns>
        public int GetGameCount() { return games.Count; }

        /// <summary>
        /// Retourne la liste de toutes les faces de dés
        /// </summary>
        /// <returns>liste des faces</returns>
        public ReadOnlyCollection<DiceSide> GetAllSides() { return diceStorage.Sides; }
        
        /// <summary>
        /// Retourne la liste de tous les dés
        /// </summary>
        /// <returns>liste des dés</returns>
        public ReadOnlyCollection<Dice> GetAllDices() { return diceStorage.Dices; }

        /// <summary>
        /// Retourne la liste de toutes les parties
        /// </summary>
        /// <returns>liste des parties</returns>
        public ReadOnlyCollection<Game> GetAllGames() { return games.AsReadOnly(); }

        /// <summary>
        /// Permet d'initialiser la liste de dés
        /// </summary>
        /// <param name="ld">liste des dés</param>
        public void InitDices(List<Dice> ld) 
        {
            diceStorage.InitDices(ld);
        }

        /// <summary>
        /// Permet d'initialiser la liste des faces de dés
        /// </summary>
        /// <param name="lds">liste des faces</param>
        public void InitSides(List<DiceSide> lds)
        {
            diceStorage.InitSides(lds);
        }

        /// <summary>
        /// Permet d'initialiser la liste des parties
        /// </summary>
        /// <param name="lg">liste des parties</param>
        public void InitGames(List<Game> lg)
        {
            if (lg == null) return;
            lg.Clear();
            foreach(Game g in lg)
            {
                games.Add(g);
            }
        }

    }
}
