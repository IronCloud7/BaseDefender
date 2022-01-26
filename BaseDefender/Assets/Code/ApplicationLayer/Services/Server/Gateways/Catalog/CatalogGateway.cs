using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.Services.Server.Dtos.Catalog;

namespace ApplicationLayer.Services.Server.Gateways.Catalog
{
    public interface CatalogGateway
    {
        Task<IReadOnlyList<CatalogItemDto>> GetItems<T>(string catalogId);
    }
}
