

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLib
{
    public class DiceSideType_entity
    {
        public long Id { get; set; }

        public int NbSide { get; set; }

        public long? Side_FK { get; set; }
        [ForeignKey("Side_FK")]
        public DiceSide_entity Prototype { get; set; }

        [Required]
        public long? Dice_FK { get; set; }
        [ForeignKey("Dice_FK")]
        public Dice_entity Dice { get; set; }
    }
}
