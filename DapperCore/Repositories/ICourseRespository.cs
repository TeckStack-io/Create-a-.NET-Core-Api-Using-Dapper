using DapperCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperCore.Repositories
{
    public interface ICourseRespository
    {
        Task<List<Course>> All();
    }
}