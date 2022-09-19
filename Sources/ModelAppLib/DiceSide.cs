using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAppLib
{
    public class DiceSide
    {
        private String Image;

        /// <summary>
        /// Construit une face de dé
        /// </summary>
        /// <param name="image">url de l'image de la face</param>
        public DiceSide(string image)
        {
            this.Image = image;
        }
    }
}
