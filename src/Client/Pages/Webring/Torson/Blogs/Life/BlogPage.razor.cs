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
            _lifeBlogService.UserId = UserId;
            _lifeBlog = await _lifeBlogService.GetByIdAsync(Id);
            if (_lifeBlog?.Content is null)
            {
                _navigation.NavigateTo($"/{UserId}");
                return;
            }
            _lifeBlog.Id = Id;
            const string format = "yyyy-MM-dd";
            _lifeBlog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/blogs/life/{_lifeBlog.Date.ToString(format)}.html");
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private LifeBlog _lifeBlog { get; set; }
        [Inject]
        private LifeBlogService _lifeBlogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
