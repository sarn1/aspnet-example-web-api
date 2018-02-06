using Stats.DataAccess.Entities;

namespace Stats.DataAccess.Repositories
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(StatsDBContext context) : base(context) { }
    }
}