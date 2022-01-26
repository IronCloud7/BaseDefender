using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DataAccess
{
    public interface UnitsDataAccess
    {
        Task<IReadOnlyList<Unit>> GetAllUnits();
    }
}