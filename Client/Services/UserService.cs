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
    public class UserService :
        HttpResourceService<User>,
        HttpResourceGetServiceMixin<UserService, User, string>
    {
        private readonly LocalClient _client;

        public const string BaseUrl = "data/users.json";
        public override HttpClient GetHttpClient() => _client.Client;

        public UserService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> GetAsync() =>
            await this.GetAsync<UserService, User, string>(BaseUrl);
          
        public async Task<User> GetByIdAsync(string id) =>
            (await GetAsync()).SingleOrDefault(x => x.Id == id) ??
                throw new Exception($"Could not find user with id: {id}");
    }
}
