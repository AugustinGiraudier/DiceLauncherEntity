using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModelAppLib
{
    public class Dice
    {
        public long Id { get; set; }

        private static ILogger<Dice> logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Dice>();
        
        private readonly List<DiceSideType> sidesTypes;

        public ReadOnlyCollection<DiceSideType> SideTypes => sidesTypes.AsReadOnly();
        

        /// <summary>
        /// Construit un dé avec la liste de ses types de faces
        /// </summary>
        /// <param name="sidesTypes">Liste des types de faces qui sera clonnée</param>
        public Dice(List<DiceSideType> sidesTypes)
        {
            if(sidesTypes == null)
                throw new ArgumentNullException(nameof(sidesTypes));
            if (sidesTypes.Count == 0)
                throw new ArgumentException("La liste des types de faces ne peut être vide", nameof(sidesTypes));
            
            logger.LogTrace("Dice created");
            this.sidesTypes = new List<DiceSideType>();
            foreach (var sideType in sidesTypes)
            {
                if (sideType == null)
                    throw new ArgumentNullException(nameof(sidesTypes));
                this.AddSide(sideType);
            }
        }
        
        /// <summary>
        /// Construit un dé avec ses types de faces en parametre
        /// </summary>
        /// <param name="dstypes">types de face du dé</param>
        public Dice(params DiceSideType[] dstypes)
        {
            if (dstypes == null)
                throw new ArgumentNullException(nameof(dstypes));
            if (dstypes.Length == 0)
                throw new ArgumentException("La liste des types de faces ne peut être vide", nameof(dstypes));

            logger.LogTrace("Dice created");
            this.sidesTypes = new List<DiceSideType>();
            
            foreach (var sideType in dstypes)
            {
                if (sideType == null)
                    throw new ArgumentNullException(nameof(dstypes));
                this.sidesTypes.Add(sideType);
            }
        }

        /// <summary>
        /// Le nombre total de faces du dé
        /// </summary>
        /// <returns>le nombre total de faces du dé</returns>
        public int GetTotalSides()
        {
            logger.LogTrace("Dice total number of sides asked");
            int ret = 0;
            foreach(DiceSideType dst in sidesTypes)
            {
                ret += dst.NbSide;
            }
            return ret;
        }

        /// <summary>
        /// Retourne la face du dé correspondant à l'index
        /// </summary>
        /// <param name="index">index de la face dans ce dé</param>
        /// <returns>la face pointée par l'index</returns>
        public DiceSide GetSideWithItsIndex(int index)
        {
            if(index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "L'index doit être positif");
            }
            if (sidesTypes.Count == 0 || index >= GetTotalSides())
                return null;

            int idCpt = 0;
            DiceSideType dst;
            int DiceCpt = 0;

            do
            {
                dst = sidesTypes[idCpt];
                DiceCpt += dst.NbSide;
                idCpt++;
            }
            while (DiceCpt <= index);

            return dst.Prototype;
        }

        /// <summary>
        /// Ajoute un type de face au dé (additionne le nombre de face si déja existante)
        /// </summary>
        /// <param name="sideT">Type de face à ajouter</param>
        public void AddSide(DiceSideType sideT)
        {
            if (sideT == null)
                throw new ArgumentNullException(nameof(sideT));
            if (sidesTypes.Contains(sideT))
                sidesTypes.Find(x => x.Equals(sideT)).AddSides(sideT.NbSide);
            else
                sidesTypes.Add(sideT);
        }

        /// <summary>
        /// Egaux si mêmes types de faces
        /// </summary>
        /// <param name="obj">objet à comparer</param>
        /// <returns>true si égaux false sinon</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Dice d = obj as Dice;
            if (d != null)
                return this.SideTypes.SequenceEqual(d.SideTypes);
            return false;
        }

        public override int GetHashCode()
        {
            int code = 1;
            foreach(DiceSideType dt in SideTypes)
                code ^= dt.GetHashCode();
            return code;
        }
    }
}
