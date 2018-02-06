using Stats.DataAccess.Entities;

namespace Stats.DataAccess.Repositories
{
    public class EventRepository : Repository<GameEvent>
    {
        public EventRepository(StatsDBContext context) : base(context) { }
    }
}