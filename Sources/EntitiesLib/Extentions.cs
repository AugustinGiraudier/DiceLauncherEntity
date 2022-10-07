using ModelAppLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLib
{
    internal static class Extentions
    {

        public static DiceSide ToModel(this DiceSide_entity entity)
                => new DiceSide(entity.Image);
        public static DiceSide_entity ToEntity(this DiceSide model)
                => new DiceSide_entity { Image = model.Image };

        public static List<DiceSide> ToModel(this IEnumerable<DiceSide_entity> entities)
                => entities.Select(e => e.ToModel()).ToList();

        public static List<DiceSide_entity> ToEntity(this IEnumerable<DiceSide> models)
            => models.Select(m => m.ToEntity()).ToList();

    }
}
