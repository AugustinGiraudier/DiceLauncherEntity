
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLib
{
    public class DiceTypeEntity
    {
        public long Id { get; set; }
        public int NbDice { get; set; }


        public long? Dice_FK { get; set; }
        [ForeignKey("Dice_FK")]
        public DiceEntity Prototype { get; set; }


        [Required]
        public long? Game_FK { get; set; }
        [ForeignKey("Game_FK")]
        public GameEntity Game { get; set; }
    }
}
