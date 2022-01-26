using ApplicationLayer.Services.Server.Dtos;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Server.Gateways.ServerData
{
    public interface Gateway
    {
        //Task InitializeData();
        Task<T> Get<T>() where T : Dto;
        Task<bool> Contains<T>() where T : Dto;
        void Set<T>(T data) where T : Dto;
        Task Save();
    }
}
