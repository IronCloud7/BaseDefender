using ApplicationLayer.Services.Server.Gateways;
using System;
using UnityEngine;

namespace ApplicationLayer.Services.Server.Dtos.User
{
    [Serializable]
    public class IsInitializedDto : Dto
    {
        [SerializeField]
        private bool _isInitialized;

        public bool IsInitialized => _isInitialized;   
    }


}
