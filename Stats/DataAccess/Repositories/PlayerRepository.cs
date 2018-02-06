using Stats.DataAccess.Entities;

namespace Stats.DataAccess.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(StatsDBContext context) : base(context) { }
    }
}