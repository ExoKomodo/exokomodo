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
    public class BabyCarrierBlogService :
        HttpResourceService<BabyCarrierBlog>,
        HttpResourceGetServiceMixin<BabyCarrierBlogService, BabyCarrierBlog, string>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public BabyCarrierBlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<BabyCarrierBlog>> GetAsync() => await this.GetAsync("blogs/baby-carrier/blogs.json");
        
        public async Task<IEnumerable<BabyCarrierBlog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<BabyCarrierBlogService, BabyCarrierBlog, string>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<BabyCarrierBlog> GetByIdAsync(string id) => await GetByIdAsync(id, "blogs/baby-carrier/blogs.json");

        public async Task<BabyCarrierBlog> GetByIdAsync(string id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return blogs.SingleOrDefault(x => x.Id == id)
                ?? throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
