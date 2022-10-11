
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLib
{
    public class DiceType_entity
    {
        public long Id { get; set; }
        public int NbDice { get; set; }


        public long? Dice_FK { get; set; }
        [ForeignKey("Dice_FK")]
        public Dice_entity Prototype { get; set; }


        [Required]
        public long? Game_FK { get; set; }
        [ForeignKey("Game_FK")]
        public Game_entity Game { get; set; }
    }
}
