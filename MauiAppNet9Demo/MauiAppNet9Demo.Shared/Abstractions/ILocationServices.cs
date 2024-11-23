using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNet9Demo.Shared.Abstractions
{
    public interface ILocationServices
    {
        Task<LocationDTO> GetCurrentLocation();
        void CancelRequest();
    }
}
