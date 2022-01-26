using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Services.Server.Dtos.Catalog;
using Domain.Services.Serializer;
using PlayFab.ClientModels;

namespace ApplicationLayer.Services.Server.Gateways.Catalog
{
    public class CatalogGatewayImpl : CatalogGateway
    {
        private readonly CatalogService _catalogService;
        private readonly SerializerService _serializerService;
        
        private readonly Dictionary<string, List<CatalogItemDto>> _items;

        public CatalogGatewayImpl(SerializerService serializerService, CatalogService catalogService)
        {
            _serializerService = serializerService;
            _catalogService = catalogService;

            _items = new Dictionary<string, List<CatalogItemDto>>();
        }

        public async Task<IReadOnlyList<CatalogItemDto>> GetItems<T>(string catalogId)
        {
            var alreadyCached = _items.ContainsKey(catalogId);
            if (!alreadyCached)
            {
                await GetItemsFromServer<T>(catalogId);
            }

            return GetCachedItems(catalogId);
        }

        private List<CatalogItemDto> GetCachedItems(string catalogId)
        {
            return _items[catalogId];
        }

        private async Task GetItemsFromServer<T>(string catalogId)
        {
            var optionalItems = await _catalogService.GetItems(catalogId);
            optionalItems
                .IfPresent(Items => { ParseCatalogItems<T>(catalogId, Items); })
                .OrElseThrow(new Exception());
        }

        private void ParseCatalogItems<T>(string catalogId, List<CatalogItem> Items)
        {
            var result = new List<CatalogItemDto>(Items
                                    .Select( ParseCatalogItem<T> ));

            _items.Add(catalogId, result);
        }

        private CatalogItemDto ParseCatalogItem<T>(CatalogItem item)
        {
            return new CatalogItemDto
            (
                item.ItemId,
                item.DisplayName,
                _serializerService.Deserialize<T>(item.CustomData)
             );
        }
    }
}