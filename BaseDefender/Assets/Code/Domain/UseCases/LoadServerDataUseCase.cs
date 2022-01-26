
using Domain.DataAccess;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class LoadServerDataUseCase : ServerDataLoader
    {
        private readonly UnitsDataAccess _unitsDataAccess;

        public LoadServerDataUseCase(UnitsDataAccess unitsDataAccess)
        {
            _unitsDataAccess = unitsDataAccess;
        }

        public async Task Load()
        {
            await _unitsDataAccess.GetAllUnits();
        }
    }
}

