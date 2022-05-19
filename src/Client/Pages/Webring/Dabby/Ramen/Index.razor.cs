using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Pages.Webring.Jorson;
using Client.Services.Jorson;
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
            _blogService.UserId = UserId;
            _blogs = await _blogService.GetAsync();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<RamenBlog> _blogs { get; set; }
        [Inject]
        private BlogService<RamenBlog> _blogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
