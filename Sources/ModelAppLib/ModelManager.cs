using System;
using System.Collections.Generic;

namespace ModelAppLib
{
    public class ModelManager
    {
        private readonly IDataManager dataManager;

        public ModelManager(IDataManager dManager)
        {
            if (dManager == null)
                throw new ArgumentNullException(nameof(dManager), "le gestionnaire de données ne peut etre null");
            
            this.dataManager = dManager;
        }
        
        /// <summary>
        /// Ajoute un dé au stockage
        /// </summary>
        /// <param name="d">dé à ajouter</param>
        public void AddDice(Dice d) 
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d), "le dé ne peut etre null");
            dataManager.AddDice(d);
        }
        /// <summary>
        /// Ajoute une partie au stockage
        /// </summary>
        /// <param name="g">partie à ajouter</param>
        public void AddGame(Game g)
        {
            if(g == null)
                throw new ArgumentNullException(nameof(g), "la partie ne peut etre null");
            dataManager.AddGame(g);
        }

        /// <summary>
        /// Retourne le nombre de dés du stockage
        /// </summary>
        /// <returns>le nombre de dés</returns>
        public int GetDiceCount() { return dataManager.GetNbDice().Result; }

        /// <summary>
        /// Retourne le nombre de faces de dé du stockage
        /// </summary>
        /// <returns>le nombre de faces</returns>
        public int GetSideCount() { return dataManager.GetNbSide().Result; }

        /// <summary>
        /// Retourne le nombre de parties du stockage
        /// </summary>
        /// <returns>nombre de parties</returns>
        public int GetGameCount() { return dataManager.GetNbGame().Result; }

        /// <summary>
        /// Retourne la IEnumerablee de toutes les faces de dés
        /// </summary>
        /// <returns>IEnumerablee des faces</returns>
        public IEnumerable<DiceSide> GetAllSides() { return dataManager.GetAllSides().Result; }
        
        /// <summary>
        /// Retourne la IEnumerablee de tous les dés
        /// </summary>
        /// <returns>IEnumerablee des dés</returns>
        public IEnumerable<Dice> GetAllDices() { return dataManager.GetAllDices().Result; }

        /// <summary>
        /// Retourne la IEnumerablee de toutes les parties
        /// </summary>
        /// <returns>IEnumerablee des parties</returns>
        public IEnumerable<Game> GetAllGames() { return dataManager.GetAllGames().Result; }

        /// <summary>
        /// Récupère un nombre de face avec un offset
        /// </summary>
        /// <param name="nb">nombre de face</param>
        /// <param name="page">offset (commence à 0)</param>
        /// <returns></returns>
        public IEnumerable<DiceSide> GetSomeSides(int nb, int page) { return dataManager.GetSomeSides(nb, page).Result; }

        /// <summary>
        /// Récupère un nombre de dé avec un offset
        /// </summary>
        /// <param name="nb">nombre de dé</param>
        /// <param name="page">offset (commence à 0)</param>
        /// <returns></returns>
        public IEnumerable<Dice> GetSomeDices(int nb, int page) { return dataManager.GetSomeDices(nb, page).Result; }

        /// <summary>
        /// Récupère un nombre de partie avec un offset
        /// </summary>
        /// <param name="nb">nombre de partie</param>
        /// <param name="page">offset (commence à 0)</param>
        /// <returns></returns>
        public IEnumerable<Game> GetSomeGames(int nb, int page) { return dataManager.GetSomeGames(nb, page).Result; }

        /// <summary>
        /// Supprime un dé
        /// </summary>
        /// <param name="d">le dé</param>
        /// <returns></returns>
        public bool RemoveDice(Dice d) { return dataManager.DeleteDice(d).Result; }

        /// <summary>
        /// Supprime une face
        /// </summary>
        /// <param name="ds">la face</param>
        /// <returns></returns>
        public bool RemoveSide(DiceSide ds) { return dataManager.DeleteSide(ds).Result; }

        /// <summary>
        /// Supprime une partie
        /// </summary>
        /// <param name="g">la partie</param>
        /// <returns></returns>
        public bool RemoveGame(Game g) { return dataManager.DeleteGame(g).Result; }

    }
}
