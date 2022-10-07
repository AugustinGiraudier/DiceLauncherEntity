using Microsoft.EntityFrameworkCore;

namespace EntitiesLib
{
    public class DiceLauncher_DbContext : DbContext
    {
        public DbSet<Dice_entity> Dices { get; set; }
        public DbSet<DiceSide_entity> DiceSides { get; set; }
        public DbSet<Game_entity> Games { get; set; }
        public DbSet<DiceSideType_entity> DiceSideTypes { get; set; }
        public DbSet<DiceType_entity> DiceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DiceLauncher.db");
        }
    }
}
