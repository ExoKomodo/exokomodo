using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Client.Services.Jorson;
using Client.Http;
using Client.Models.Jorson.Blogs;

namespace Client.Pages.Users.Jorson.Blogs.Food
{
	internal class BlogPageBase : PageBase {}

    public partial class BlogPage
    {
        #region Public

        #region Constructors
        public BlogPage()
        {
            _base = new BlogPageBase();
        }
        #endregion

        #region Members
        [Parameter]
        public string Id { get; set; }
        #endregion

        #region Constants
        public static string UserId = "jorson";
        #endregion

        #region Member Methods
        public async void ScrollTo(string targetId) {
            if (targetId.StartsWith("#")) {
                targetId = targetId[1..];
            }
            await _jsRuntime.InvokeVoidAsync(
                "scrollIntoView",
                targetId
            );
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                _base.Initialize();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _foodBlogService.UserId = UserId;
            _blog = await _foodBlogService.GetByIdAsync(Id, "food/food.json");
            if (_blog?.Content is null)
            {
                _navigation.NavigateTo($"/users/{UserId}/food");
                return;
            }
            _blog.Id = Id;
            if (!string.IsNullOrWhiteSpace(_blog.Content.Path))
            {
                _blog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_blog.Content.Path}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private FoodBlog _blog { get; set; }
        [Inject]
        private FoodBlogService _foodBlogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
