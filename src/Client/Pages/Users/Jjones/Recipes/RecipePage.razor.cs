using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Models.Jorson;
using Client.Services.Jorson;
using Client.Http;
using Client.Pages.Users.Jorson;

namespace Client.Pages.Users.Jjones.Recipes
{
  internal class RecipePageBase : PageBase {}

    public partial class RecipePage
    {
        #region Public

        #region Constructors
        public RecipePage()
        {
            _base = new RecipePageBase();
        }
        #endregion

        #region Members
        [Parameter]
        public int Id { get; set; }
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
            _recipe = await _blogService.GetByIdAsync(Id, "recipes/recipes.json");
            if (_recipe?.Content is null)
            {
                _navigation.NavigateTo($"/users/{UserId}/recipes");
                return;
            }
            _recipe.Id = Id;
            if (!string.IsNullOrWhiteSpace(_recipe.Content.Path))
            {
                _recipe.Content.Text = await _localClient.Client.GetStringAsync($"/data/{UserId}/{_recipe.Content.Path}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Blog<int> _recipe { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}
