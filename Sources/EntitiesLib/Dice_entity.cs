

using System.Collections.Generic;

namespace EntitiesLib
{
    public class Dice_entity
    {
        public long Id { get; set; }

        public ICollection<DiceSideType_entity> Sides { get; set; } = new List<DiceSideType_entity>();
    }
}
