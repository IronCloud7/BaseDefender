using ApplicationLayer.Services.Server.Dtos.Server;
using ApplicationLayer.Services.Server.Gateways.Catalog;
using Domain.DataAccess;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationLayer.DataAccess
{
    public class UnitsRepository : UnitsDataAccess
    {
        private readonly CatalogGateway _catalogGateway;
        private List<Unit> _units;

        public UnitsRepository(CatalogGateway catalogGateway)
        {
            _catalogGateway = catalogGateway;
        }

        public async Task<IReadOnlyList<Unit>> GetAllUnits()
        {
           var unitsDtos = await _catalogGateway.GetItems<UnitCustomData>("Units");

            _units = new List<Unit>(unitsDtos           
                .Select(unitDto =>
                {
                    var unitCustomData = unitDto.GetCustomData<UnitCustomData>();
                    return new Unit(unitDto.ID,
                                    unitDto.DisplayName,
                                    unitCustomData.Attack,
                                    unitCustomData.Health);
                }));

            return _units;
        }
    }
}
