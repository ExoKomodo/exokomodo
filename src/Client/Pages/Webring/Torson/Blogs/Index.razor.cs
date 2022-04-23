using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models.Jorson.Blogs;
using Client.Services.Jorson;
using Microsoft.AspNetCore.Components;

namespace Client.Pages.Webring.Torson.Blogs
{
	public partial class Index
    {
        public IEnumerable<Blog<int>> blogs = new List<Blog<int>>();
        public static string UserId = "torson";

        protected override async Task OnInitializedAsync()
        {
            _blogService.UserId = UserId;
            blogs = await _blogService.GetAsync();
        }

        [Inject]
        private BlogService<Blog<int>> _blogService { get; set; }
    }
}