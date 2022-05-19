using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Http;
using Client.Models;
using Client.Services.Mixins;

namespace Client.Services
{
    public class WebringService :
        HttpResourceService<Page>,
        HttpResourceGetServiceMixin<WebringService, Page, string>
    {
        private readonly LocalClient _client;

        public const string BaseUrl = "data/pages.json";
        public override HttpClient GetHttpClient() => _client.Client;

        public WebringService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Page>> GetAsync() =>
            await this.GetAsync<WebringService, Page, string>(BaseUrl);
          
        public async Task<Page> GetByIdAsync(string id) =>
            (await GetAsync()).SingleOrDefault(x => x.Id == id) ??
                throw new Exception($"Could not find page with id: {id}");
    }
}
