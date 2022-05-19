using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Pages.Webring.Jorson;
using Client.Services.Jorson;
using Client.Models.Dabby.Blogs;

namespace Client.Pages.Webring.Dabby.Ramen
{
	internal class RamenBlogPageBase : PageBase {}

    public partial class RamenBlogPage
    {
        #region Public

        #region Constructors
        public RamenBlogPage()
        {
            _base = new RamenBlogPageBase();
        }
        #endregion

        #region Members
        [Parameter]
        public int Id { get; set; }
        #endregion

        #region Constants
        public const string UserId = "dabby";
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
            _blogService.UserId = UserId;
            _blog = await _blogService.GetByIdAsync(Id);
            if (_blog is null)
            {
                _navigation.NavigateTo($"/webring/{UserId}/ramen-blog");
            }
            _blog.Id = Id;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private RamenBlog _blog { get; set; }
        [Inject]
        private BlogService<RamenBlog> _blogService { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
