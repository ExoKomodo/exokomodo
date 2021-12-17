using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models.Jorson;
using Client.Services.Jorson;
using Microsoft.AspNetCore.Components;

namespace Client.Pages.Users.Torson.Blogs
{
    public partial class Index
    {
        public IEnumerable<Blog> blogs = new List<Blog>();
        public const string UserId = "torson";

        public Index()
        {}

        protected override async Task OnInitializedAsync()
        {
            _blogService.UserId = UserId;
            blogs = await _blogService.GetAsync();
        }

        [Inject]
        private BlogService _blogService { get; set; }
    }
}