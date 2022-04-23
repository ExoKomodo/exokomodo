using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models.Jorson.Blogs;
using Client.Services.Jorson;
using Client.Pages.Webring.Jorson;

namespace Client.Pages.Webring.Jjones.Recipes
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
        public const string UserId = "jjones";
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
            _recipes = await _blogService.GetAsync("recipes/recipes.json");
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<GeneralBlog> _recipes { get; set; }
        [Inject]
        private BlogService<GeneralBlog> _blogService { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
