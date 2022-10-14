using System;
using System.Runtime.CompilerServices;

namespace ModelAppLib
{
    /// <summary>
    /// Classe modélisant une face de dé
    /// </summary>
    public class DiceSide
    {

        public long Id { get; set; }
        public String Image { get;}

        /// <summary>
        /// Construit une face de dé
        /// </summary>
        /// <param name="image">url de l'image de la face</param>
        public DiceSide(string image)
        {
            if(image == null)
                throw new ArgumentNullException(nameof(image), "l'image ne peut pas etre null");
            this.Image = image;
        }

        /// <summary>
        /// Egaux si même image
        /// </summary>
        /// <param name="obj">objet à comparer</param>
        /// <returns>true si égaux false sinon</returns>
        public override bool Equals(object obj)
        {
            DiceSide ds = obj as DiceSide;
            if (ds != null)
                return this.Image.Equals(ds.Image);
            return false;
        }

        public override int GetHashCode()
        {
            return Image.GetHashCode();
        }

    }
}
