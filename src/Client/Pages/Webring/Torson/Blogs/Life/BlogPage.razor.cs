using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Models.Torson.Blogs;
using Client.Http;
using Client.Services.Torson;

namespace Client.Pages.Webring.Torson.Blogs.Life
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
        public int Id { get; set; }
        #endregion

        #region Constants
        public const string UserId = "torson";
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
            _lifeblogService.UserId = UserId;
            _lifeblog = await _lifeblogService.GetByIdAsync(Id);
            if (_lifeblog?.Content is null)
            {
                _navigation.NavigateTo($"/{UserId}");
                return;
            }
            _lifeblog.Id = Id;
            if (!string.IsNullOrWhiteSpace(_lifeblog.Content.Path))
            {
                _lifeblog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_lifeblog.Content.Path}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private LifeBlog _lifeblog { get; set; }
        [Inject]
        private LifeBlogService _lifeblogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
