
namespace EntitiesLib
{
    public class DiceType_entity
    {
        public long Id { get; set; }
        public int NbDice { get; set; }

        public Dice_entity Prototype { get; set; }
    }
}
