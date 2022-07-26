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
    public class BookBlogService :
        HttpResourceService<BookBlog>,
        HttpResourceGetServiceMixin<BookBlogService, BookBlog, string>
    {
        private readonly LocalClient _client;
    
        public override HttpClient GetHttpClient() => _client.Client;
        
        public string UserId { get; set; } = "";

        public BookBlogService(LocalClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<BookBlog>> GetAsync() => await this.GetAsync("blogs/book/blogs.json");
        
        public async Task<IEnumerable<BookBlog>> GetAsync(string dataFilePath) =>
            await this.GetAsync<BookBlogService, BookBlog, string>(
                $"data/{UserId}/{dataFilePath}"
            );

        public async Task<BookBlog> GetByIdAsync(string id) => await GetByIdAsync(id, "blogs/book/blogs.json");

        public async Task<BookBlog> GetByIdAsync(string id, string dataFilePath)
        {
            var blogs = (await GetAsync(dataFilePath)).ToList();
            return blogs.SingleOrDefault(x => x.Id == id)
                ?? throw new Exception($"Could not find blog with id: {id}");
        }
    }
}
