using Stats.DataAccess.Entities;

namespace Stats.DataAccess.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public GameRepository(StatsDBContext context) : base(context) { }
    }
}