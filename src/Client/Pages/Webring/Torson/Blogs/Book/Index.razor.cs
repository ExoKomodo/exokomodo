using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Services.Torson;
using Client.Models.Torson.Blogs;

namespace Client.Pages.Webring.Torson.Blogs.Book
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
            _bookBlogService.UserId = UserId;
            _bookBlogs = await _bookBlogService.GetAsync();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<BookBlog> _bookBlogs { get; set; }
        [Inject]
        private BookBlogService _bookBlogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
