using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemUtilities;
using ApplicationLayer.Services.Server.Gateways.Catalog;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace ApplicationLayer.Services.Server.PlayFab.Catalog
{
    public class PlayFabCatalogService : CatalogService
    {
        public Task<Optional<List<CatalogItem>>> GetItems(string catalogId)
        {
            var t = new TaskCompletionSource<Optional<List<CatalogItem>>>();

            GetCatalogItems(catalogId, t);

            return Task.Run(() => t.Task);
        }

        private void GetCatalogItems(string catalogId, TaskCompletionSource<Optional<List<CatalogItem>>> t)
        {
            var request = new GetCatalogItemsRequest
            {
                CatalogVersion = catalogId
            };

            PlayFabClientAPI.GetCatalogItems(request,
                result => OnSuccess(result, t),
                error => OnError(error, t)
                );
        }

        protected void OnSuccess(GetCatalogItemsResult result, TaskCompletionSource<Optional<List<CatalogItem>>> taskCompletionSource)
        {
    
            taskCompletionSource.SetResult(new Optional<List<CatalogItem>>(result.Catalog));
            Debug.Log("Ok Catalog");
        }


        protected void OnError(PlayFabError error, TaskCompletionSource<Optional<List<CatalogItem>>> taskCompletionSource)
        {
            throw new Exception(error.ErrorMessage);
        }
    }
}