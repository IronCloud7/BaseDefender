using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemUtilities;

namespace ApplicationLayer.Services.Server.Gateways.ServerData
{
    public interface GetDataService
    {
        Task<Optional<DataResult>> Get(List<string> keys);
        
    }
}
