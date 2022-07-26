using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Services.Torson;
using Client.Models.Torson.Blogs;

namespace Client.Pages.Webring.Torson.Blogs.BabyCarrier
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
            _babyCarrierBlogs = await _babyCarrierBlogService.GetAsync();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<BabyCarrierBlog> _babyCarrierBlogs { get; set; }
        [Inject]
        private BabyCarrierBlogService _babyCarrierBlogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
