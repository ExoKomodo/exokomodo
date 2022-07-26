using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Http;
using Client.Models.Dabby.Blogs;
using Client.Services.Mixins;

namespace Client.Services.Dabby
{
    public class RamenBlogService :
        HttpResourceService<RamenBlog>,
        HttpResourceGetServiceMixin<RamenBlogService, RamenBlog, int>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public RamenBlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<RamenBlog>> GetAsync() => await this.GetAsync("blogs/ramen/blogs.json");
        
        public async Task<IEnumerable<RamenBlog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<RamenBlogService, RamenBlog, int>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<RamenBlog> GetByIdAsync(int id) => await GetByIdAsync(id, "blogs/ramen/blogs.json");

        public async Task<RamenBlog> GetByIdAsync(int id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return blogs.SingleOrDefault(x => x.Id == id)
                ?? throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
