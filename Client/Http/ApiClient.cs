using System.Net.Http;

namespace Client.Http
{
    public class ApiClient {
        public readonly HttpClient Client;
        public ApiClient(HttpClient client)
        {
            Client = client;
        }
    }
}