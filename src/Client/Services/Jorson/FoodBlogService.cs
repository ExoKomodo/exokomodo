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
    public class FoodBlogService :
        HttpResourceService<FoodBlog>,
        HttpResourceGetServiceMixin<FoodBlogService, FoodBlog, string>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public FoodBlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<FoodBlog>> GetAsync() => await this.GetAsync("blogs/blogs.json");
        
        public async Task<IEnumerable<FoodBlog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<FoodBlogService, FoodBlog, string>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<FoodBlog> GetByIdAsync(string id) => await GetByIdAsync(id, "blogs/blogs.json");

        public async Task<FoodBlog> GetByIdAsync(string id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return blogs.SingleOrDefault(x => x.Id == id)
                ?? throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
