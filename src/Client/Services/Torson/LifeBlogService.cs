using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Http;
using Client.Models.Torson.Blogs;
using Client.Services.Mixins;

namespace Client.Services.Torson
{
    public class LifeBlogService :
        HttpResourceService<LifeBlog>,
        HttpResourceGetServiceMixin<LifeBlogService, LifeBlog, int>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public LifeBlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<LifeBlog>> GetAsync() => await this.GetAsync("blogs/life/blogs.json");
        
        public async Task<IEnumerable<LifeBlog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<LifeBlogService, LifeBlog, int>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<LifeBlog> GetByIdAsync(int id) => await GetByIdAsync(id, "blogs/life/blogs.json");

        public async Task<LifeBlog> GetByIdAsync(int id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return blogs.SingleOrDefault(x => x.Id == id)
                ?? throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
