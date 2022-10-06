﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelAppLib
{
    public class ModelManager
    {
        private IDataManager dataManager;

        public ModelManager(IDataManager dManager)
        {
            if (dManager == null)
            {
                throw new System.ArgumentNullException(nameof(dManager));
            }
            this.dataManager = dManager;
        }
        
        /// <summary>
        /// Ajoute un dé au stockage
        /// </summary>
        /// <param name="d">dé à ajouter</param>
        public void AddDice(Dice d) 
        {
            dataManager.AddDice(d);
        }
        /// <summary>
        /// Ajoute une partie au stockage
        /// </summary>
        /// <param name="g">partie à ajouter</param>
        public void AddGame(Game g)
        {
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
        /// Retourne la liste de toutes les faces de dés
        /// </summary>
        /// <returns>liste des faces</returns>
        public List<DiceSide> GetAllSides() { return dataManager.GetAllSides().Result; }
        
        /// <summary>
        /// Retourne la liste de tous les dés
        /// </summary>
        /// <returns>liste des dés</returns>
        public List<Dice> GetAllDices() { return dataManager.GetAllDices().Result; }

        /// <summary>
        /// Retourne la liste de toutes les parties
        /// </summary>
        /// <returns>liste des parties</returns>
        public List<Game> GetAllGames() { return dataManager.GetAllGames().Result; }

    }
}
