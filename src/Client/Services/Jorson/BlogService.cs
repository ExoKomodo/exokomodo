using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Http;
using Client.Models.Jorson;
using Client.Services.Mixins;

namespace Client.Services.Jorson
{
    public class BlogService :
        HttpResourceService<Blog>,
        HttpResourceGetServiceMixin<BlogService, Blog, int>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public BlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Blog>> GetAsync() => await this.GetAsync("blogs/blogs.json");
        
        public async Task<IEnumerable<Blog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<BlogService, Blog, int>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<Blog> GetByIdAsync(int id) => await GetByIdAsync(id, "blogs/blogs.json");

        public async Task<Blog> GetByIdAsync(int id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return (id >= 0 && id < blogs.Count) ?
                blogs[id] :
                throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
