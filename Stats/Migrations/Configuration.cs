namespace Stats.Migrations
{
    using Stats.DataAccess.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Stats.DataAccess.Entities.StatsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Stats.DataAccess.Entities.StatsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // create players
            var p1 = new Player { FirstName = "John", LastName = "Doe", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var p2 = new Player { FirstName = "Frank", LastName = "Foe", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var p3 = new Player { FirstName = "Billy", LastName = "Lee", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var p4 = new Player { FirstName = "Bob", LastName = "Johnson", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };

            // create teams
            var t1 = new Team { Name = "Bears", CreatedDate = DateTime.Now, Players = new List<Player> { p1, p2 }, UpdatedDate = DateTime.Now };
            var t2 = new Team { Name = "Eagles", CreatedDate = DateTime.Now, Players = new List<Player> { p3, p4 }, UpdatedDate = DateTime.Now };

            // assign team to players
            p1.Team = t1;
            p2.Team = t1;
            p3.Team = t2;
            p4.Team = t2;

            // create game
            var game = new Game { AwayTeam = t1, HomeTeam = t2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, StartTime = DateTime.Now };

            // put into db
            context.Players.Add(p1);
            context.Players.Add(p2);
            context.Players.Add(p3);
            context.Players.Add(p4);
            context.Teams.Add(t1);
            context.Teams.Add(t2);
            context.Games.Add(game);
        }
    }
}
