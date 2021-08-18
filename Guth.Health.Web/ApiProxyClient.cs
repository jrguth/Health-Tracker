using System;
using System.Net.Http;
using System.Threading.Tasks;
using Health.Web.Api.Client;
using StrawberryShake;

namespace Guth.Health.Web
{
    public class ApiProxyClient : HttpClient
    {
        private readonly IHoopApiClient _hoopApiClient;

        public ApiProxyClient(IHoopApiClient hoopApiClient)
        {
            _hoopApiClient = hoopApiClient;
        }
    }
}
