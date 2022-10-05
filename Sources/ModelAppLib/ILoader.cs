using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public interface ILoader
    {
        /// <summary>
        /// Permet de récupérer tous les dés
        /// </summary>
        /// <returns>liste de tous les dés</returns>
        public Task<List<Dice>> GetAllDices();

        /// <summary>
        /// Permet de récupérer toutes les faces
        /// </summary>
        /// <returns>liste de toutes les faces</returns>
        public Task<List<DiceSide>> GetAllSides();

        /// <summary>
        /// Permet de récupérer toutes les parties
        /// </summary>
        /// <returns>liste des parties</returns>
        public Task<List<Game>> GetAllGames();

        /// <summary>
        /// Permet de récupérer certains dés
        /// </summary>
        /// <param name="nb">Nombre de dés à récupérer</param>
        /// <param name="page">Numéro de la page (nombre de séquence de 'nb' éléments à skip)</param>
        /// <returns></returns>
        public Task<List<Dice>> GetSomeDices(int nb, int page);

        /// <summary>
        /// Permet de récupérer certaines faces de dé
        /// </summary>
        /// <param name="nb">Nombre de faces à récupérer</param>
        /// <param name="page">Numéro de la page (nombre de séquence de 'nb' éléments à skip)</param>
        /// <returns></returns>
        public Task<List<DiceSide>> GetSomeSides(int nb, int page);

        /// <summary>
        /// Permet de récupérer certaines parties
        /// </summary>
        /// <param name="nb">Nombre de parties à récupérer</param>
        /// <param name="page">Numéro de la page (nombre de séquence de 'nb' éléments à skip)</param>
        /// <returns></returns>
        public Task<List<Game>> GetSomeGames(int nb, int page);

    }
}
