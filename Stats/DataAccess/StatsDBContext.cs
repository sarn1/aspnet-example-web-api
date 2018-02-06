using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Entities
{
	public class StatsDBContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<GameEvent> Events { get; set; }
	}
}