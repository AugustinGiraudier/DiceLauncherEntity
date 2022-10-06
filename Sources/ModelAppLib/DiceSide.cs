﻿using System;
using System.Runtime.CompilerServices;

namespace ModelAppLib
{
    public class DiceSide
    {
        public String Image { get;}

        /// <summary>
        /// Construit une face de dé
        /// </summary>
        /// <param name="image">url de l'image de la face</param>
        public DiceSide(string image)
        {
            if(image == null)
                throw new ArgumentNullException("image");
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
