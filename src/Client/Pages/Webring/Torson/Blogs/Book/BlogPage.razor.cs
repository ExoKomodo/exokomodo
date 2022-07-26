using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Models.Torson.Blogs;
using Client.Http;
using Client.Services.Torson;

namespace Client.Pages.Webring.Torson.Blogs.Book
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
            _bookBlogService.UserId = UserId;
            _bookBlog = await _bookBlogService.GetByIdAsync(Id);
            if (_bookBlog?.Content is null)
            {
                _navigation.NavigateTo($"/{UserId}");
                return;
            }
            _bookBlog.Id = Id;
            if (!string.IsNullOrWhiteSpace(_bookBlog.Content.Path))
            {
                _bookBlog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_bookBlog.Content.Path}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private BookBlog _bookBlog { get; set; }
        [Inject]
        private BookBlogService _bookBlogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
