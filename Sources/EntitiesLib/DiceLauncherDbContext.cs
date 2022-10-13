using Microsoft.EntityFrameworkCore;

namespace EntitiesLib
{
    public class DiceLauncherDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<DiceEntity> Dices { get; set; }
        public DbSet<DiceSideEntity> Sides { get; set; }

        public DiceLauncherDbContext() { }
        public DiceLauncherDbContext(DbContextOptions<DiceLauncherDbContext> options)
            :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=DiceLauncher.db");
        }

    }
}
