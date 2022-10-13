

using System.Collections.Generic;

namespace EntitiesLib
{
    public class DiceEntity
    {
        public long Id { get; set; }

        public ICollection<DiceSideTypeEntity> Sides { get; set; } = new List<DiceSideTypeEntity>();
    }
}
