


using System.Collections.Generic;

namespace EntitiesLib
{
    public class Game_entity
    {
        public long Id { get; set; }

        public ICollection<DiceType_entity> DiceTypes { get; set; } = new List<DiceType_entity>();
    }
}
