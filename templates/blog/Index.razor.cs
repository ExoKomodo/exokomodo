using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models.Jorson;
using Client.Services.Jorson;

namespace Client.Pages.Users.UserId.Blogs
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
        public static string UserId = "user id";
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
        private IEnumerable<Blog<int>> _blogs { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
