using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Http;
using Client.Models.Jorson.Blogs;
using Client.Services.Mixins;

namespace Client.Services.Jorson
{
    public class BlogService<T> :
        HttpResourceService<T>,
        HttpResourceGetServiceMixin<BlogService<T>, T, int>
        where T : Blog<int>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public BlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<T>> GetAsync() => await this.GetAsync("blogs/blogs.json");
        
        public async Task<IEnumerable<T>> GetAsync(string dataFilePath) =>
            await this.GetAsync<BlogService<T>, T, int>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<T> GetByIdAsync(int id) => await GetByIdAsync(id, "blogs/blogs.json");

        public async Task<T> GetByIdAsync(int id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return (id >= 0 && id < blogs.Count) ?
                blogs[id] :
                throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
