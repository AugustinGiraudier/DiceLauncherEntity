

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLib
{
    public class DiceSideTypeEntity
    {
        public long Id { get; set; }

        public int NbSide { get; set; }

        public long? Side_FK { get; set; }
        [ForeignKey("Side_FK")]
        public DiceSideEntity Prototype { get; set; }

        [Required]
        public long? Dice_FK { get; set; }
        [ForeignKey("Dice_FK")]
        public DiceEntity Dice { get; set; }
    }
}
