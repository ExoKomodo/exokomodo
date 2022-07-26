using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Models.Torson.Blogs;
using Client.Http;
using Client.Services.Torson;

namespace Client.Pages.Webring.Torson.Blogs.BabyCarrier
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
            _babyCarrierBlogService.UserId = UserId;
            _babyCarrierBlog = await _babyCarrierBlogService.GetByIdAsync(Id);
            if (_babyCarrierBlog?.Content is null)
            {
                _navigation.NavigateTo($"/{UserId}");
                return;
            }
            _babyCarrierBlog.Id = Id;
            if (!string.IsNullOrWhiteSpace(_babyCarrierBlog.Content.Path))
            {
                _babyCarrierBlog.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_babyCarrierBlog.Content.Path}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private BabyCarrierBlog _babyCarrierBlog { get; set; }
        [Inject]
        private BabyCarrierBlogService _babyCarrierBlogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
