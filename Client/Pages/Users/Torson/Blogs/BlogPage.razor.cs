using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Client.Models.Jorson;
using Client.Services.Jorson;
using Client.Http;

namespace Client.Pages.Users.Torson.Blogs
{
    public partial class BlogPage
    {
        [Parameter]
        public int Id { get; set; }
        public const string UserId = "torson";

        protected override async Task OnInitializedAsync()
        {
            _blogService.UserId = UserId;
            _blog = await _blogService.GetByIdAsync(Id);
            if (_blog?.Content is null)
            {
                _navigation.NavigateTo($"/users/{UserId}/blog");
                return;
            }
            _blog.Id = Id;
            if (!string.IsNullOrWhiteSpace(_blog.Content.Path))
            {
                _blog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_blog.Content.Path}");
            }
        }

        private Blog _blog { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
    }
}
