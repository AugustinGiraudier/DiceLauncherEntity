using System;

namespace ModelAppLib
{
    /// <summary>
    /// Classe modélisant un type de face avec son prototype de référence ainsi que sa quantité
    /// </summary>
    public class DiceSideType
    {
        /// <summary>
        /// Nombre de face de ce type
        /// </summary>
        public int NbSide { get; private set; }

        public DiceSide Prototype { get; private set; }

        /// <summary>
        /// Construit un type de face avec un prototype et une quantité
        /// </summary>
        /// <param name="nbSide">Nombre d'occurence de ce type de face</param>
        /// <param name="prototype">Type de face</param>
        public DiceSideType(int nbSide, DiceSide prototype)
        {
            if (nbSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(nbSide),"le nombre de face doit être suppérieur à 0");
            if (prototype == null)
                throw new ArgumentNullException(nameof(prototype));
            NbSide = nbSide;
            this.Prototype = prototype;
        }

        /// <summary>
        /// Ajoute des faces à ce type de face
        /// </summary>
        /// <param name="nbToAdd">Nombre de face à ajouter</param>
        public void AddSides(int nbToAdd)
        {
            if (nbToAdd <= 0)
                throw new ArgumentOutOfRangeException(nameof(nbToAdd), "le nombre de face à ajouter doit être suppérieur à 0");
            NbSide += nbToAdd;
        }

        /// <summary>
        /// Egaux si même prototype
        /// </summary>
        /// <param name="obj">objet à comparer</param>
        /// <returns>true si égaux false sinon</returns>
        public override bool Equals(object obj)
        {
            DiceSideType dst = obj as DiceSideType;
            if (dst != null)
                return (this.NbSide == dst.NbSide && this.Prototype.Equals(dst.Prototype));
            return false;
        }

        public override int GetHashCode()
        {
            return this.Prototype.GetHashCode() ^ NbSide;
        }
    }
}
