using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ModelAppLib_UnitTests")]
[assembly: InternalsVisibleTo("StubLib")]

namespace ModelAppLib
{
    internal interface ILoader
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

    }
}
