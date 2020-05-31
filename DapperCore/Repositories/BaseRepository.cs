using DataAbstractions.Dapper;

namespace DapperCore.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDataAccessor db;

        protected BaseRepository(IDataAccessor db)
        {
            this.db = db;
        }
    }
}
