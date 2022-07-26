using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Pages.Webring.Jorson;
using Client.Services.Dabby;
using Client.Models.Dabby.Blogs;

namespace Client.Pages.Webring.Dabby.Ramen
{
	internal class IndexBase : PageBase {}

    public partial class Index
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new IndexBase();
        }
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
            _ramenBlogService.UserId = UserId;
            _ramenBlogs = await _ramenBlogService.GetAsync();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<RamenBlog> _ramenBlogs { get; set; }
        [Inject]
        private RamenBlogService _ramenBlogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
