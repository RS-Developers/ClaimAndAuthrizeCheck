using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess
{
    public class StatesDbContext : DbContext//, IDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }

        public StatesDbContext() 
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StatesDbContext, Migrations.Configuration>());
        }

        public StatesDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StatesDbContext, Migrations.Configuration>());
        }
    }
}