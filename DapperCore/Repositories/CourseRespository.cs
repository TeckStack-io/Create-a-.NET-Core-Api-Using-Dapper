using DapperCore.Models;
using DataAbstractions.Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCore.Repositories
{
    public class CourseRespository : BaseRepository, ICourseRespository
    {
        public CourseRespository(IDataAccessor db) : base(db) { }

        public async Task<List<Course>> All()
        {
            var query = "select [Id], [Name] from Itrn_Course";

            var results = await db.QueryAsync<Course>(query);

            return results.ToList();
        }
    }
}
