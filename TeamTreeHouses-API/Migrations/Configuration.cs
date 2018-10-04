namespace TeamTreeHouses_API.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeamTreeHouses_API.DataAccess;
    using TeamTreeHouses_API.DataAccess.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<StatesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StatesDbContext context)
        {
            if (!context.Database.Exists())
                context.Database.CreateIfNotExists();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Database.Exists() &&
                context.Players.Count() == 0)
            {
                var lPlayer1 = new Player() { FirstName = "John", LastName = "Doe", CreateDate = DateTime.Now, UpdateDate = DateTime.Now };
                var lPlayer2 = new Player() { FirstName = "Frank", LastName = "Doe", CreateDate = DateTime.Now, UpdateDate = DateTime.Now };
                var lPlayer3 = new Player() { FirstName = "Robbie", LastName = "Johnson", CreateDate = DateTime.Now, UpdateDate = DateTime.Now };
                var lPlayer4 = new Player() { FirstName = "Billy", LastName = "Bob", CreateDate = DateTime.Now, UpdateDate = DateTime.Now };
                //
                var lTeam1 = new Team() { Name = "Rhinos", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Players = new List<Player> { lPlayer1, lPlayer2 } };
                var lTeam2 = new Team() { Name = "Eagles", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Players = new List<Player> { lPlayer3, lPlayer3 } };
                //
                lPlayer1.Team = lTeam1;
                lPlayer2.Team = lTeam1;
                lPlayer3.Team = lTeam2;
                lPlayer4.Team = lTeam2;
                //
                var lGame = new Game() { AwayTeam = lTeam1, HomeTeam = lTeam2, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, StartTime = DateTime.Now };
                //
                context.Players.Add(lPlayer1);
                context.Players.Add(lPlayer2);
                context.Players.Add(lPlayer3);
                context.Players.Add(lPlayer4);
                //
                context.Teams.Add(lTeam1);
                context.Teams.Add(lTeam2);
                //
                context.Games.Add(lGame);
                //
                context.SaveChanges();
            }//end if
        }
    }
}
