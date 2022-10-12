using Microsoft.EntityFrameworkCore;

namespace EntitiesLib
{
    public class DiceLauncher_DbContext : DbContext
    {
        public DbSet<Game_entity> Games { get; set; }
        public DbSet<Dice_entity> Dices { get; set; }
        public DbSet<DiceSide_entity> Sides { get; set; }

        public DiceLauncher_DbContext() { }
        public DiceLauncher_DbContext(DbContextOptions<DiceLauncher_DbContext> options)
            :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=DiceLauncher.db");
        }

    }
}
